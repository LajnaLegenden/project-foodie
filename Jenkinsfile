pipeline {
    agent any
    stages {
        stage('Pre Build') {
            steps {
                sh 'chmod +x -R ./scripts/'
                sh 'pwd'
                sh 'env'
                sh 'ssh-keyscan 10.147.20.156 >> ~/.ssh/known_hosts'
                sh 'pwd'
            }
        }
        stage('Build') {
            steps {
                sh './scripts/pipeline/build.py'
            }
        }
        stage('Test') {
            steps {
                echo 'No tests'
            }
        }
        stage('Deploy') {
            steps {
                sh './scripts/pipeline/deploy.py'
            }
        }
        stage('Confirm') {
            steps {
                sh './scripts/pipeline/confirm.py'
            }
        }
    }
}
