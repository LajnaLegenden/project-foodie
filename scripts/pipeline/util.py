import json
import subprocess
import os


def getConfig(branch):
    # get this file directory
    dir_path = os.path.dirname(os.path.realpath(__file__))
    with open(dir_path + '/config.json') as f:
        config = json.load(f)
    if branch not in config:
        return config['default']
    return config[branch]

def getImageTag(config):
    return config['hostname'] + ":latest"

def hasOwnConfig(config):
    dir_path = os.path.dirname(os.path.realpath(__file__))
    with open(dir_path + '/config.json') as f:
        config = json.load(f)
    if branch not in config:
        return False
    return True

def printLine(line):
    line = line.decode('utf-8').strip()
    obj = json.loads(line)
    if 'stream' in obj:
        print(obj['stream'].strip())
    elif 'status' in obj:
        # priunt with color
        print(f"{bcolors.OKGREEN}{obj['status'].strip()}{bcolors.ENDC}")
        # print(obj['status'].strip() + " " + obj['progressDetail'].strip())
    elif 'errorDetail' in obj:
        print("Error: " + obj['errorDetail']['message'])
        exit(1)
    elif 'aux' in obj:
        print("Image built: " + obj['aux']['ID'])
    else:
        print(line)


def getGitBranch():
    return subprocess.check_output(['git', 'rev-parse', '--abbrev-ref', 'HEAD']).decode('utf-8').strip()


class bcolors:
    HEADER = '\033[95m'
    OKBLUE = '\033[94m'
    OKCYAN = '\033[96m'
    OKGREEN = '\033[92m'
    WARNING = '\033[93m'
    FAIL = '\033[91m'
    ENDC = '\033[0m'
    BOLD = '\033[1m'
    UNDERLINE = '\033[4m'
