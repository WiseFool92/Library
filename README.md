# _Library_

#### June 2nd, 2020

## Description

_This application will allow the user to create a virtual library collection of books and allow users to view the stock & check them out_

_This application is meant to be viewed in the browser & will need a .NET Core Sdk 3.1 or 2.2 & ASP.Net 3.1 or 2.2 download as well as connect to a MySql Database_

## Setup/Installation Requirements

_Make sure you have [git version control](https://git-scm.com/downloads) installed on your computer._

1. Click the green 'Clone or Download' button and copy the link / download the zip
2. Open terminal and type... or skip to #4 if you downloaded the zip

**Windows**

```sh
cd desktop
```

Mac & linux

```sh
cd ~/Desktop
```

3.  in terminal type '_git clone {link to repository}_ '

```sh
git clone {link to repository}
```
4. If you downloaded the zip then extract all onto your desktop
5. Open the folder with VSC or an equivalent
6. Install .NET Core using <a href="https://docs.microsoft.com/en-us/dotnet/core/install/runtime?pivots=os-windows">this</a> link
7. Then Run the code below in the terminal to confirm installation
```sh
dotnet -- version
```  
8. In the terminal enter to confirm the proper version installed 
```sh
dotnet tool install -g 
dotnet-script
```
9. Download _[ASP.NET Core](https://dotnet.microsoft.com/download)_ To enable live viewing on a local server
10. Open project, navigate to the containing folder of the project & Run the code below to confirm build stability
```sh
dotnet run build 
```
11. Within that same containing folder Run _dotnet watch run_ To open a live server w/auto updated viewing
12. If you want to run tests navigate to the .tests containing folder and enter
```sh
dotnet test
```
13. Enjoy

## Specs

### Behavior Driven Development Spec List
#### Library
|                          Behavior                          | Input  | Output  |
| :--------------------------------------------------------: | :----: | :-----: |
| The program | '' | '' |
| The program | '' | '' |
| The program | '' | '' |
| The program | '' | '' |
| The program | '' | '' |

---
## Known Bugs

_N/A_ - 5/8/2020

## gh-pages

WiseFool92.github.io/Library

## Support

_Email: watkins92@gmail.com_

---
## Built With

- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [MSTest](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest)

## Useful tools

- [free icons @ icons8](https://icons8.com/)
- [free icons @ fontawesome](https://fontawesome.com/)

---

- [Old School Gifs Search](https://gifcities.org/)
- [free images @ unsplash](https://unsplash.com/)

  - **_source.unsplash.com_ will return a random image at a desired size by simply calling the size after the url followed by a '?' and a keyword. Example below**

  - _https://source.unsplash.com/400x400/?cat_
  - http://unsplash.it/500/500 - This will just return a random image the size of 500x500

---

- [Flex-box Cheat Sheet](http://yoksel.github.io/flex-cheatsheet/)
- [CSS Grid Cheat Sheet](http://grid.malven.co/)

---

- [CSS Gradient BG Generator](https://mycolor.space/gradient)
- [CSS Basic Gradient Generator](https://cssgradient.io/)

---

- [CSS Dropshadow Generator](https://cssgenerator.org/box-shadow-css-generator.html)

### License

This project is licensed under the MIT License

Copyright (c) 2020 **_Nathan Watkins-Hoagland_**
