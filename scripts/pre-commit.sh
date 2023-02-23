#!/bin/bash
FILES=$(git diff --cached --name-only --diff-filter=ACMR "*.css" | sed 's| |\\ |g')

if [[ -z "$FILES" ]]; then
  echo "PRECOMMIT[pass]: No CSS files to check."
  exit 0
fi
echo "Autoprefixing files"

# loop over files
for FILE in $FILES; do
  # check if file exists
  if [ -f "$FILE" ]; then
    # run postcss
    echo "PRECOMMIT[pass]: $FILE"
    npx postcss $FILE -o $FILE
    # add file to commit
    git add $FILE
  fi
done
