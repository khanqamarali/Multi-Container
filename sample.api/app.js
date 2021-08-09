const express = require('express')
const config = require('config')
const mysql = require('mysql2')
const app = express()
app.use(express.json())
// var con = mysql.createConnection({
//     host: "localhost",
//     port:"3306",
//     user: "root",
//     password: "password",
//     database:"appdb" 
//   });

var con = mysql.createConnection({
    host: config.get('host'),
    port:"3306",
    user: config.get('user'),
    password: config.get('pwd'),
    database: "appdb"
  });

app.get('/',(req,res)=>{
console.log('test')
   con.connect(function(err) {
        if (err) throw err;
        console.log("Connected!");
      });
      var result = con.query("select * from user;",function(err,result)
      {
        if (err) throw err;
        res.send(result)  
      })
    

   // res.send('Hello from Node '+ config.get('key') + '--env--'+ config.get('dbconn'))
})

app.listen(3001,()=>{console.log('port 3001')})