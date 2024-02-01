## Test making an API app
I created this after meddling with the other PokemonAPI program I tried to fix earlier.
Turns out, it is easier to just code everything back to remove that SQLServer on-build.
My azure server runs effortlessly and I love it. The only thing bugging me is that when I use my React Front-end to fetch it. It is quite slow to make connection from all 3 parts of the full application. Vercel for FE, Asure for BE, Aiven.io for the Database.
I use my own MySQL remote server which I configured in the App Json file. Thanks to Aiven.io for the free plan!
- **Here is the SwaggerUI to help you test with it**: [swagger](https://peopleapi1141.azurewebsites.net/swagger/index.html)
- **Here is the link to my front-end if you are curious about what the data look like**: [react](https://github.com/Rous1141/learning03) 
