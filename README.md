## How to run in Docker from the commandline

Build in container
```
docker build -t web_ovi .
```

to runweb_container_ovi

```
docker run -d -p 8081:80 --name web_container_ovi web_ovi
```

to stop container
```
docker stop web_container_ovi
```

to remove container
```
docker rm web_container_ovi
```

## Deploy to heroku

1. Create heroku account
2. Create application
3. Make sure application works locally in Docker


Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a webapp-sandbox-ovi web
```

Release the container
```
heroku container:release -a webapp-sandbox-ovi web
```