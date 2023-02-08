#!/usr/bin/env python3

import json
import requests
import util as u
import time as time
import sys
def main():
    print("Starting confirm")
    branch = u.getGitBranch()
    config = u.getConfig(branch)

    if(not u.hasOwnConfig(branch)):
        print("No config for branch " + branch)
        print("Skipping confirm")
        exit(0)
    # make sure the server responds with a 200 giving it 20 attempts and 3 seconds between each attempt
    url = config['url']

    num_attempts = 20
    while num_attempts > 0:
        try:
            print("Attempting to connect to server: " + url + " attempt: " + str(20-num_attempts) + "/20")
            response = requests.get(url)
            if response.status_code == 200:
                break
        except:
            pass
        num_attempts -= 1
        time.sleep(3)
    if num_attempts == 0:
        print("Server failed to start")
        exit(1)
    print("Server started successfully")



if __name__ == "__main__":
    main()
