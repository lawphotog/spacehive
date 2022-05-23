# Spacehive

## basket

sample end points

## Goods

GET
https://localhost:5001/Goods?selectedCurrency=usd

## Basket

GET
https://localhost:5001/Basket/Get?selectedCurrency=usd

POST
https://localhost:5001/Basket/Add?goodsId=1&basketId=1
https://localhost:5001/Basket/Remove?goodsId=1&basketId=1

## how to run the API

replace API_KEY for currency api in launch.json

open in VSCode
F5

## how to run tests

dotnet test src/spacehive.core.tests
dotnet test src/spacehive.domain.tests