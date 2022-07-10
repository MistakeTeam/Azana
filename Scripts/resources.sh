#!/bin/bash

# Mistake Team (R) Algo ¯\_(ツ)_/¯
# Copyright (C) Mistake Team. Todos os direitos reservados.



SCRIPTPATH="$(cd -- "$(dirname "${BASH_SOURCE[0]:-$0}")" >/dev/null 2>&1 ; pwd -P)"
SOURCEPATH="$(cd -- "$(dirname "$SCRIPTPATH")" >/dev/null 2>&1 ; pwd -P)"
BUILDPATH="$(cd -- "$(dirname "$SCRIPTPATH")/build" >/dev/null 2>&1 ; pwd -P)"
#echo $SCRIPTPATH
#echo $SOURCEPATH
#echo $BUILDPATH
#echo  "$( dirname -- "$( readlink -f -- "$0" )" )"


cd $BUILDPATH/debug
mkdir -p resources

echo X----------------------X

for caminho in $SOURCEPATH/mistaketeam.azana/texto/*; do
    if [ -d "$caminho" ]; 
    then
        lang="${caminho##*/}"
        
        if [ ! -z $1 ] && [[ $1 == $lang ]] || [ -z $1 ]
        then
            echo "Construindo resources '$lang'..."

            wd=`bash $SCRIPTPATH/find_filter.sh $SOURCEPATH/mistaketeam.azana/texto/$lang *.txt`
            resgen $wd resources/$lang.resources /useSourcePath
        fi
    fi
done
