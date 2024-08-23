Welcome to our Chinese sale!

How to use my project: In order to run this project you need: VS version 2022 (and more). .net 7 (and more). DB- SQL server. To create the DB, you can use the capabilities of Code First. All you need is: Open your package manager console, type: add-migration [DataBaseName] and then: Update-DataBase.

And the DB is ready to use!

About our project: The project represents a Chinese sale. Go to the Login page.
 The user gets the option to register in the case of a new user. After successful login, you arrive at a page where you can buy tickets. On this page you can add product cards to your cart. There is an option to filter the cards you see using a category, to sort the cards of the products by price (increasing / decreasing). You can click and go to your cart page, where you can see your cart, remove tickets from it, and save your order.
Our project in .net7, written by web API .net core and follows the principles of REST architecture. We used a SQL Server database.

 The project of the struct is made of layers connecting them with Dependency Injections, in order to gain the benefits of the DI in making the application more fluid and flexible, allows parallel development, disconnection between the class and its dependencies. We used an asynchronous function to add scalability. We have a cheat that describes the structure of our project, if you want, you can use it by the path:"localhost:[PORT NUMBER]/swagger" and see everything neatly documented.

The project maps the objects using the AutoMapper package. We created middleware to handle errors.

Hope you enjoyed reading and benefited from it
Shifra
