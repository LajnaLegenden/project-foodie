#!/usr/bin/env python3
import os
import sys
import subprocess
import json
import docker
import util as u


def main():
    branch = u.getGitBranch()
    config = u.getConfig(branch)
    print("Starting build for branch " + branch +
          " and hostname " + config['hostname'])
    client = docker.APIClient(base_url=config['daemon'])


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


    # print stream of build output as it happens
    for line in client.build(path="./", tag=u.getImageTag(config),environment=env):
        u.printLine(line)


if __name__ == "__main__":
    main()
