#!/usr/bin/env python3
import os
import sys
import subprocess
import json
import docker
import util as u


def main():
    # take in arguments
    if len(sys.argv) != 2:
        print("Usage: python3 test.py <test>")
        exit(1)
    test = sys.argv[1]
    #check that it is api angular or monitor
    if test != "api" and test != "angular" and test != "monitor":
        print("Invalid test")
        exit(1)

    print("Starting test: " + test)
    branch = u.getGitBranch()
    config = u.getConfig(branch)
    client = docker.DockerClient(base_url=config['daemon'])
    container = client.containers.run(image=u.getImageTag(config), command="test " + test, remove=True, detach=True)
    
    # print logs
    for line in container.logs(stream=True):
        print(line.decode('utf-8').strip())
    
    # remove container
    container.remove()

if __name__ == "__main__":
    main()