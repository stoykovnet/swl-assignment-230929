#!/bin/bash

read -p "Enter GitHub repository name (must be lower case): " repoName
read -p "Enter the port that microservice is going to operate on (format: XXXX): " newPort
read -p "Enter the name for the solution (f.x. Webinars): " solutionName
read -p "Enter the task number for plumbing of this service (XXXX): " taskNumber

find ./ -name '*.*' -exec sed -i "" "s/<REPO_NAME>/${repoName}/gi" {} \;
find ./ -name '*.*' -exec sed -i "" "s/<NEW_PORT>/${newPort}/gi" {} \;
find ./ -name '*.*' -exec sed -i "" "s/<SOLUTION_NAME>/${solutionName}" {} \;
find ./ -name '*.*' -exec sed -i "" "s/RepoTemplate/${solutionName}/gi" {} \;
find ./ -name 'Dockerfile*' -exec sed -i "" "s/RepoTemplate/${solutionName}/gi" {} \;

$(mv RepoTemplate.API/RepoTemplate.API.csproj RepoTemplate.API/$solutionName.API.csproj)
$(mv RepoTemplate.API/ $solutionName.API)

$(mv RepoTemplate.API.Swagger/RepoTemplate.API.Swagger.csproj RepoTemplate.API.Swagger/$solutionName.API.Swagger.csproj)
$(mv RepoTemplate.API.Swagger/ $solutionName.API.Swagger)

$(mv RepoTemplate.Extensions/RepoTemplate.Extensions.csproj RepoTemplate.Extensions/$solutionName.Extensions.csproj)
$(mv RepoTemplate.Extensions/ $solutionName.Extensions)

$(mv RepoTemplate.Mappers/RepoTemplate.Mappers.csproj RepoTemplate.Mappers/$solutionName.Mappers.csproj)
$(mv RepoTemplate.Mappers/ $solutionName.Mappers)

$(mv RepoTemplate.Models/RepoTemplate.Models.csproj RepoTemplate.Models/$solutionName.Models.csproj)
$(mv RepoTemplate.Models/ $solutionName.Models)

$(mv RepoTemplate.Services/RepoTemplate.Services.csproj RepoTemplate.Services/$solutionName.Services.csproj)
$(mv RepoTemplate.Services/ $solutionName.Services)

$(mv RepoTemplate.Tests/RepoTemplate.Tests.csproj RepoTemplate.Tests/$solutionName.Tests.csproj)
$(mv RepoTemplate.Tests/ $solutionName.Tests)

$(mv RepoTemplate.Tests.Integration/RepoTemplate.Tests.Integration.csproj RepoTemplate.Tests.Integration/$solutionName.Tests.Integration.csproj)
$(mv RepoTemplate.Tests.Integration/ $solutionName.Tests.Integration)

if [ -f RepoTemplate.Service.sln ]; then
    $(mv RepoTemplate.Service.sln $solutionName.Service.sln)
    echo "Plumbing done successfully, you can now commit changes and push it to the plumbing branch"
fi

rm README.MD

git checkout -b task/AB#${taskNumber}-plumbing
git add .
git commit -m "Plubming"
git push -u origin task/AB#${taskNumber}-plumbing

rm plumbing.sh