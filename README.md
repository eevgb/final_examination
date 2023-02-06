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
   25  lsb_release -cs
   26  sudo apt-get install lsb-release
   27  sudo dpkg -i mysql-apt-config_0.8.24-1_all.deb
   28  sudo apt-get update
   29  sudo apt-get install mysql-server
   30  mysql --version
   31  cd /etc
   32  ls
   33  cd apt
   34  ls
   35  cd apt.conf.d
   36  ls
   37  cd ../
   38  cd ./sources.list.d
   39  ls
   40  cat mysql.list
   41  cd /tmp
   42  wget http://ftp.ru.debian.org/debian/pool/main/h/htop/htop_3.0.5-7_amd64.deb
   43  dpkg -i htop_3.0.5-7_amd64.deb
   44  sudo dpkg -i htop_3.0.5-7_amd64.deb
   45  htop
   46  htop --version
   47  sudo dpkg -r htop
   48  cd ~
   49  ls
   50  ls -la
   51  history
```

## Работа с SQL

Описание решений заданий по работе с БД выполнено в файле [WorkWithSQL.md](WorkWithSQL.md) 

## Приложение имитирующее работу реестра домашних животных

Описание решения выполнено в файле [ApplicationReadme.md](ApplicationReadme.md)


