pipeline {
  agent any
  stages {
    stage('Pre Build') {
      steps {
        sh 'chmod +x -R ./scripts/'
        sh 'pwd'
        sh 'env'
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