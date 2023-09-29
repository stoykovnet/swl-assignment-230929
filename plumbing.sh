#!/bin/bash

read -p "Enter GitHub repository name (must be lower case): " repoName
read -p "Enter the port that microservice is going to operate on (format: XXXX): " newPort
read -p "Enter the name for the solution (f.x. Webinars): " solutionName
read -p "Enter the task number for plumbing of this service (XXXX): " taskNumber

find ./ -name '*.*' -exec sed -i "" "s/pet-store/${repoName}/gi" {} \;
find ./ -name '*.*' -exec sed -i "" "s/8080/${newPort}/gi" {} \;
find ./ -name '*.*' -exec sed -i "" "s/<SOLUTION_NAME>/${solutionName}" {} \;
find ./ -name '*.*' -exec sed -i "" "s/PetStore/${solutionName}/gi" {} \;
find ./ -name 'Dockerfile*' -exec sed -i "" "s/PetStore/${solutionName}/gi" {} \;

$(mv PetStore.API/PetStore.API.csproj PetStore.API/$solutionName.API.csproj)
$(mv PetStore.API/ $solutionName.API)

$(mv PetStore.API.Swagger/PetStore.API.Swagger.csproj PetStore.API.Swagger/$solutionName.API.Swagger.csproj)
$(mv PetStore.API.Swagger/ $solutionName.API.Swagger)

$(mv PetStore.Extensions/PetStore.Extensions.csproj PetStore.Extensions/$solutionName.Extensions.csproj)
$(mv PetStore.Extensions/ $solutionName.Extensions)

$(mv PetStore.Mappers/PetStore.Mappers.csproj PetStore.Mappers/$solutionName.Mappers.csproj)
$(mv PetStore.Mappers/ $solutionName.Mappers)

$(mv PetStore.Models/PetStore.Models.csproj PetStore.Models/$solutionName.Models.csproj)
$(mv PetStore.Models/ $solutionName.Models)

$(mv PetStore.Services/PetStore.Services.csproj PetStore.Services/$solutionName.Services.csproj)
$(mv PetStore.Services/ $solutionName.Services)

$(mv PetStore.Tests/PetStore.Tests.csproj PetStore.Tests/$solutionName.Tests.csproj)
$(mv PetStore.Tests/ $solutionName.Tests)

$(mv PetStore.Tests.Integration/PetStore.Tests.Integration.csproj PetStore.Tests.Integration/$solutionName.Tests.Integration.csproj)
$(mv PetStore.Tests.Integration/ $solutionName.Tests.Integration)

if [ -f PetStore.Service.sln ]; then
    $(mv PetStore.Service.sln $solutionName.Service.sln)
    echo "Plumbing done successfully, you can now commit changes and push it to the plumbing branch"
fi

rm README.MD

git checkout -b task/AB#${taskNumber}-plumbing
git add .
git commit -m "Plubming"
git push -u origin task/AB#${taskNumber}-plumbing

rm plumbing.sh