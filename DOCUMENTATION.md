# asp-net-core-project
ASP.NET Core Blog project for school
Dusan Nikolic 1/15

Tema projekta je blog. 

Postoje Postovi koji imaju tagove, komentare, i ocene.
Svaki post moze imati vise tagova.
Svaki tag moze imati vise postova. m:m
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Svaki post moze imati vise komentara i ocena 1:m 
Za 
user
comment
post
pic
tag
log(samo read, usecase sam insertuje) je uradjen kompletan CRUD.
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Radjen je CodeFirst, UseCase, Statusni kodovi su obradjeni,  GlobalExceptionHandler,FluentValidator, EmailSender, JWT, Swagger, sve je radjeno osim AutoMapera. 
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
COMMAND	ID
addcom	1
addpic	2
addtag	3
adduser	4
addpost	5
editpost	6
editcom	7
editpic	8
edituser	9
edittag	10
deletepost	11
deletecom	12
deletepic	13
deleteuser	14
deletetag	15
getpost	16
getcom	17
getpic	18
getuser	19
gettag	20
getallpost	21
getallcom	22
getallpic	23
getalluser	24
getalltag	25
uploadfile	26
getUseCaseLogs	33
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Tabele u bazi su: 
Comments
  Pictures
  posts
  PostTags
  Tag
  UseCaseLogs
  Users
  UserUseCase
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Srecno pregledanje!
