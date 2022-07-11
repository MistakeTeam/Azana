#!/bin/bash

# Mistake Team (R) Algo ¯\_(ツ)_/¯
# Copyright (C) Mistake Team. Todos os direitos reservados.

cd ..

if [ -z $1 ]
then
echo "😅 Sem comentários não rola"
exit 0
fi


#git init

git add ${2|.}
git commit -m "$1"
#git remote add origin https://github.com/MistakeTeam/Azana
#git push -u -f origin master
git push

