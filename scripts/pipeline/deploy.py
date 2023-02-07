#!/bin/env python3
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

    if(not u.hasOwnConfig(config)):
        print("No config for branch " + branch)
        print("Skipping deploy")
        exit(0)

    client = docker.DockerClient(base_url=config['daemon'])

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

    ports = {80: config['port'], 443: config["port"] + 443}
    client.containers.create(image=u.getImageTag(config), name=config['hostname'], ports=ports, detach=True).start()


if __name__ == "__main__":
    main()
