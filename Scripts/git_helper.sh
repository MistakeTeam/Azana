#!/bin/bash

# Mistake Team (R) Algo ¯\_(ツ)_/¯
# Copyright (C) Mistake Team. Todos os direitos reservados.

cd ..

if [ -z $1 ]
then
echo "😅 Sem comentários não rola"
exit 0
fi
echo $1

#git init

git add .
git commit -m "$1"
#git remote add origin https://github.com/cameronmcnz/example-website.git
#git push -u -f origin master
git push

