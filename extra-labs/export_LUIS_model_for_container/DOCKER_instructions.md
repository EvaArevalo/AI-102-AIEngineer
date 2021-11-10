# Docker instructions

## Pull docker image

```
docker pull mcr.microsoft.com/azure-cognitive-services/language/luis:latest
```

## Run docker image
```
docker run --rm -it -p 5000:5000 --memory 4g --cpus 2 `
--mount type=bind,src=D:\GitRepos-misc\AI-102-AIEngineer\extra-labs\export_LUIS_model_for_container\input,target=/input `
--mount type=bind,src=D:\GitRepos-misc\AI-102-AIEngineer\extra-labs\export_LUIS_model_for_container\output,target=/output `
mcr.microsoft.com/azure-cognitive-services/language/luis `
Eula=accept `
Billing=https://australiaeast.api.cognitive.microsoft.com/ `
ApiKey=5e3ff4d446b04942aab5cac433fcb8df
```

after running, API will be launched as localhost:5000 API service

# References

http://studyhost.blogspot.com/2021/01/luis.html