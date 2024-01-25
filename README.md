## Test making an API app
I created this after meddling with the other PokemonAPI program I tried to fixed earlier.
Turns out, it easier to just code everything back to remove that SQLServer on-build.
My own azure server run effortlessly and I love it. The only thing bugging me is that when I use my React Front-end to fetch it. It is quite slow to make connection from all 3 parts of the full application. Vercel for FE, Asure for BE, Aiven.io for the Database.
I use my own MySQL remote server with I configured in the App Json file. Thanks to Aiven.io for the free plan!
- **Here is the SwaggerUI to help you testing with it**: [swagger](https://peopleapi1141.azurewebsites.net/swagger/index.html)
- **Here is the link to my front-end with you are curious what the datas look like**: [react](https://github.com/Rous1141/learning03) 
