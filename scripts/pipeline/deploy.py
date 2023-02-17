#!/usr/bin/env python3
import os
import sys
import subprocess
import json
import docker
import util as u


def main():
    print("Starting deploy")
    branch = u.getGitBranch()
    config = u.getConfig(branch)
    client = docker.DockerClient(base_url=config['daemon'])

    if(not u.hasOwnConfig(branch)):
        print("No config for branch " + branch)
        try:
            container = client.containers.get(config['hostname'])
            container.remove()
        except docker.errors.NotFound:
            pass
        print("Skipping deploy")
        exit(0)


    # stop and remove old container
    try:
        print("Stopping old container")
        container = client.containers.get(config['hostname'])
        container.stop()
        container.remove()
    except docker.errors.NotFound:
        print("No old container found")
    # start new container
    print("Starting new container")
        # get jenkins home directory from environment
    jenkins_home = os.environ['JENKINS_HOME']
    # cehck if jenkinshomee/env exists
    if not os.path.exists(jenkins_home + "/env"):
        os.makedirs(jenkins_home + "/env")
    #check if env file exists
    if not os.path.isfile(jenkins_home + "/env/" + config['env']):
        # create env file
        with open(jenkins_home + "/env/" + config['env'], 'w') as env_file:
            env_file.write("")
    #add env to container
    env = []
    with open(jenkins_home + "/env/" + config['env'], 'r') as env_file:
        for line in env_file:
            env.append(line.rstrip())


    ports = {5000: config['port'], 5001: config["port"] + 443}
    client.containers.create(image=u.getImageTag(config), name=config['hostname'], ports=ports, detach=True, environment=env).start()


if __name__ == "__main__":
    main()
