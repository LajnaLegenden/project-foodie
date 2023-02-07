for value in MenuContext OrderContext
do
    cd src/
    dotnet ef database update --context $value
done