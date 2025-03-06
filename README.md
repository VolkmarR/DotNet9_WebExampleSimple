# DotNet9_WebExampleSimple

This is an example project that shows, step by step, how to build a simple web application with asp.net core 9.0. 

## Result

The example is a simplified version of www.sli.do, a website for audiences to ask questions to the speaker.

It shows a list of questions. The users can add new questions to the list and vote for questions. 

## Used server side frameworks

* .Net 9
* Asp.net core 9
* Swashbuckle 7.2
* Entity framework core 9

## Used client side frameworks
* Twitter Bootstrap
* Vue.js
* Axios
 
## Steps

To recreate this project, these four steps should be followed. For a detailed description of each step, click on the corresponding header. This repository also contains a folder for each step, that shows the state of the solution after completing the corresponding step.

### [Step 0 - Set up the project](Step0.md)

Create new projects for the Web Application and add the Swagger UI.

### [Step 1 - DB implementation](Step1.md)

Add the implementation for the database access (SQLite).

### [Step 2 - Web Api implementation](Step2.md)

Add the API Routes. 

### [Step 3 - Add website](Step3.md)

Add the implementation of the frontend.
