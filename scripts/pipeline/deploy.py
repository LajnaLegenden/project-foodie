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
    client = docker.DockerClient(base_url=config['daemon'])

    # stop and remove old container
    try:
        container = client.containers.get(config['hostname'])
        container.stop()
        container.remove()
    except docker.errors.NotFound:
        print("No old container found")
    # start new container
    print("Starting new container")
    client.containers.create(image=u.getImageTag(config), name=config['hostname'], ports={
                             config['port']: 80}, detach=True).start()


if __name__ == "__main__":
    main()
