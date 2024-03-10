create database security;
use security;

create table user(
id int auto_increment,
name varchar(255) UNIQUE,
password varchar(255),
profile_picture blob(10000000),
primary key(id)
);

create table objednavka(
id int auto_increment,
message varchar(255),
is_visible bit,
user_id int,
foreign key (user_id) references user(id) ON DELETE CASCADE ON UPDATE CASCADE,
primary key(id)
);

select u.name, u.profile_picture, o.id, o.message, o.is_visible
from user as u
left join objednavka o on u.id = o.user_id;