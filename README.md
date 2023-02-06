# Итоговая аттестация

## Информация о проекте
Необходимо организовать систему учета для питомника, в котором живут домашние и вьючные животные.  
Как сдавать проект  
Для сдачи проекта необходимо создать отдельный общедоступный репозиторий(Github, gitlub, или Bitbucket). 
Разработку вести в этом репозитории, использовать пул реквесты на изменения. Программа должна запускаться и работать, 
ошибок при выполнении программы быть не должно.  
Программа, может использоваться в различных системах, поэтому необходимо разработать класс в виде конструктора

## Задание
1. Используя команду cat в терминале операционной системы Linux, создать два файла Домашние животные 
(заполнив файл собаками, кошками, хомяками) и Вьючные животными заполнив файл Лошадьми, верблюдами и ослы), 
а затем объединить их. Просмотреть содержимое созданного файла.  
Переименовать файл, дав ему новое имя (Друзья человека).

### Решение

```shell
eev@DESKTOP-EUKEKPJ:~$ ls
eev@DESKTOP-EUKEKPJ:~$ cat > pets
Мурзик cat
Барсик cat
Шарик dog
Бобик dog
Хомчик hamster
eev@DESKTOP-EUKEKPJ:~$ cat > pack_animals
Мустанг horse
DesertShip camel
SimpleDonkey donkey
eev@DESKTOP-EUKEKPJ:~$ cat pets pack_animals > animals
eev@DESKTOP-EUKEKPJ:~$ cat animals
Мурзик cat
Барсик cat
Шарик dog
Бобик dog
Хомчик hamster
Мустанг horse
DesertShip camel
SimpleDonkey donkey
eev@DESKTOP-EUKEKPJ:~$ mv ./animals ./mans_friends
eev@DESKTOP-EUKEKPJ:~$ ls
mans_friends  pack_animals  pets
eev@DESKTOP-EUKEKPJ:~$ cat mans_friends
Мурзик cat
Барсик cat
Шарик dog
Бобик dog
Хомчик hamster
Мустанг horse
DesertShip camel
SimpleDonkey donkey
eev@DESKTOP-EUKEKPJ:~$
```

2. Создать директорию, переместить файл туда.

### Решение

```shell
eev@DESKTOP-EUKEKPJ:~$ mkdir ./animals
eev@DESKTOP-EUKEKPJ:~$ mv ./mans_friends ./animals
eev@DESKTOP-EUKEKPJ:~$ ls -la ./animals/
total 12
drwxr-xr-x 2 eev eev 4096 Feb  6 18:38 .
drwxr-xr-x 3 eev eev 4096 Feb  6 18:38 ..
-rw-r--r-- 1 eev eev  150 Feb  6 18:32 mans_friends
eev@DESKTOP-EUKEKPJ:~$
```

3. Подключить дополнительный репозиторий MySQL. Установить любой пакет из этого репозитория.

### Решение

```shell
# Обновляем, устанавливаем gnupg
eev@DESKTOP-EUKEKPJ:~$ sudo apt-get update
eev@DESKTOP-EUKEKPJ:~$ sudo apt-get upgrade
eev@DESKTOP-EUKEKPJ:~$ sudo apt-get install gnupg
eev@DESKTOP-EUKEKPJ:~$ cd /tmp
# Переходим в папку /tmp, загружаем Ubuntu / Debian (Architecture Independent), DEB Package
# который подготовит apt-репозиторий и установит ключи. Устанавливаем его
eev@DESKTOP-EUKEKPJ:/tmp$ wget https://dev.mysql.com/get/mysql-apt-config_0.8.24-1_all.deb
eev@DESKTOP-EUKEKPJ:/tmp$ sudo dpkg -i mysql-apt-config_0.8.24-1_all.deb
# В результате в /etc/apt/sources.list.d будет создан файл mysql.list
# Обновляем репозитории, устанавливаем mysql-server
eev@DESKTOP-EUKEKPJ:/tmp$ sudo apt-get update
eev@DESKTOP-EUKEKPJ:/tmp$ sudo apt-get install mysql-server
# Результат
eev@DESKTOP-EUKEKPJ:/tmp$ mysql --version
mysql  Ver 8.0.32 for Linux on x86_64 (MySQL Community Server - GPL)
```

4. Установить и удалить deb-пакет с помощью dpkg.

### Решение

```shell
# Загружаем пакет htop, устанавливаем при помощи dpkg
eev@DESKTOP-EUKEKPJ:/tmp$ wget http://ftp.ru.debian.org/debian/pool/main/h/htop/htop_3.0.5-7_amd64.deb
eev@DESKTOP-EUKEKPJ:/tmp$ sudo dpkg -i htop_3.0.5-7_amd64.deb
(Reading database ... 13930 files and directories currently installed.)
Preparing to unpack htop_3.0.5-7_amd64.deb ...
Unpacking htop (3.0.5-7) ...
Setting up htop (3.0.5-7) ...
# Проверяем установленную версию
eev@DESKTOP-EUKEKPJ:/tmp$ htop --version
htop 3.0.5
# Удаляем пакет
eev@DESKTOP-EUKEKPJ:/tmp$ sudo dpkg -r htop
(Reading database ... 13930 files and directories currently installed.)
Removing htop (3.0.5-7) ...
```

5. Выложить историю команд в терминале ubuntu.

### Решение

```shell
eev@DESKTOP-EUKEKPJ:~$ history
    1  ls
    2  cat > pets
    3  cat > pack_animals
    4  cat pets pack_animals > animals
    5  cat animals
    6  mv ./animals ./mans_friends
    7  ls
    8  less mans_friends
    9  cat mans_friends
   10  mkdir ./animals
   11  mv ./mans_friends ./animals
   12  ls -la ./animals/
   13  sudo apt-get update
   14  sudo apt-get upgrade
   15  sudo apt-get install gnupg
   16  pwd
   17  cd /tmp
   18  ls
   19  wget https://dev.mysql.com/get/mysql-apt-config_0.8.24-1_all.deb
   20  whereis wget
   21  sudo apt-get install wget
   22  wget https://dev.mysql.com/get/mysql-apt-config_0.8.24-1_all.deb
   23  ls
   24  sudo dpkg -i mysql-apt-config_0.8.24-1_all.deb
   25  sudo apt-get install mysql-apt-config_0.8.24-1_all.deb
   26  sudo dpkg -i mysql-apt-config_0.8.24-1_all.deb
   27  lsb_release -cs
   28  sudo apt-get install lsb-release
   29  sudo dpkg -i mysql-apt-config_0.8.24-1_all.deb
   30  sudo apt-get update
   31  sudo apt-get install mysql-server
   32  mysql --version
   33  cd /etc
   34  ls
   35  cd apt
   36  ls
   37  cd apt.conf.d
   38  ls
   39  cd ../
   40  cd ./sources.list.d
   41  ls
   42  cat mysql.list
   43  cd /tmp
   44  wget http://ftp.ru.debian.org/debian/pool/main/h/htop/htop_3.0.5-7_amd64.deb
   45  dpkg -i htop_3.0.5-7_amd64.deb
   46  sudo dpkg -i htop_3.0.5-7_amd64.deb
   47  htop
   48  htop --version
   49  sudo dpkg -r htop
   50  cd ~
   51  ls
   52  ls -la
   53  history
```

6. Нарисовать диаграмму, в которой есть класс родительский класс, домашние животные и вьючные животные, 
в составы которых в случае домашних животных войдут классы: собаки, кошки, хомяки, а в класс вьючные животные 
войдут: Лошади, верблюды и ослы).
7. В подключенном MySQL репозитории создать базу данных “Друзья человека”
8. Создать таблицы с иерархией из диаграммы в БД
9. Заполнить низкоуровневые таблицы именами(животных), командами которые они выполняют и датами рождения
10. Удалив из таблицы верблюдов, т.к. верблюдов решили перевезти в другой питомник на зимовку. 
Объединить таблицы лошади, и ослы в одну таблицу.
11. Создать новую таблицу “молодые животные” в которую попадут все животные старше 1 года, но младше 3 лет и в 
отдельном столбце с точностью до месяца подсчитать возраст животных в новой таблице
12. Объединить все таблицы в одну, при этом сохраняя поля, указывающие на прошлую принадлежность к старым таблицам.
13. Создать класс с Инкапсуляцией методов и наследованием по диаграмме.
14. Написать программу, имитирующую работу реестра домашних животных.
    В программе должен быть реализован следующий функционал:  
    14.1 Завести новое животное  
    14.2 определять животное в правильный класс  
    14.3 увидеть список команд, которое выполняет животное  
    14.4 обучить животное новым командам  
    14.5 Реализовать навигацию по меню  
15. Создайте класс Счетчик, у которого есть метод add(), увеличивающий̆ значение внутренней̆ int переменной̆ на 1 
при нажатии “Завести новое животное” Сделайте так, чтобы с объектом такого типа можно было работать в 
блоке try-with-resources. Нужно бросить исключение, если работа с объектом типа счетчик была не в 
ресурсном try и/или ресурс остался открыт. Значение считать в ресурсе try, 
если при заведении животного заполнены все поля.