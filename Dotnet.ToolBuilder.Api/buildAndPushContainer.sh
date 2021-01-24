docker build . -t breinerde/dotnettoolbuilder.api:$1

docker push breinerde/dotnettoolbuilder.api:$1

docker tag breinerde/dotnettoolbuilder.api:$1 breinerde/dotnettoolbuilder.api:latest

docker push breinerde/dotnettoolbuilder.api:latest
