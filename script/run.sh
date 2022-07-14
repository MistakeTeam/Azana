#!/bin/bash

echo "Mistake Team (R) Algo ¯\_(ツ)_/¯
Copyright (C) Mistake Team. Todos os direitos reservados."


DEBUGPATH="$(cd -- "../$(dirname "${BASH_SOURCE[0]}")/build/debug" >/dev/null 2>&1 ; pwd -P)"


#bash build.sh Ajudante
#bash resources.sh
bash build.sh Azana


cd $DEBUGPATH

if [ -e Azana.exe ]
then
    mono Azana.exe
fi


