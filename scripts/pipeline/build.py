#!/bin/env python3
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
    # print stream of build output as it happens
    for line in client.build(path="./", tag=u.getImageTag(config)):
        u.printLine(line)


if __name__ == "__main__":
    main()
