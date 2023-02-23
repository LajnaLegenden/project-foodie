FILES=$(git diff --cached --name-only --diff-filter=ACMR "*.ts" "*.html" | sed 's| |\\ |g')

if [[ -z "$FILES" ]]; then
  echo "PRECOMMIT[pass]: No CSS files to check."
  exit 0
fi
echo "Autoprefixing files"

echo "$FILES" | xargs npx postcss

echo "$FILES" | xargs git add
