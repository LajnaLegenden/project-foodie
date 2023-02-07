pipeline {
  agent any
  stages {
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
        sh 'echo "no deploy specified"'
      }
    }

    stage('Confirm') {
      steps {
        echo 'no step'
      }
    }

  }
}