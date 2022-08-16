#!/bin/bash

# Mistake Team (R) Algo ¯\_(ツ)_/¯
# Copyright (C) Mistake Team. Todos os direitos reservados.


SCRIPTPATH="$(cd -- "$(dirname "${BASH_SOURCE[0]}")" >/dev/null 2>&1 ; pwd -P)"
SOURCEPATH="$(cd -- "../$(dirname "${BASH_SOURCE[0]}")" >/dev/null 2>&1 ; pwd -P)"
SCRIPTPATH=${SCRIPTPATH/"/c"/"C:"}
SOURCEPATH=${SOURCEPATH/"/c"/"C:"}

echo $SCRIPTPATH
echo $SOURCEPATH

cd $SOURCEPATH/MistakeTeam.Azana/bin/Debug/net6.0
mkdir -p resources
cd resources

for caminho in $SOURCEPATH/MistakeTeam.Azana/Texto/*; do
    if [ -d "$caminho" ]; 
    then
        echo X----------------------X
        lang="${caminho##*/}"
        mkdir -p $lang
        cd $lang
        
        if [ ! -z $1 ] && [[ $1 == $lang ]] || [ -z $1 ]
        then
            echo "Construindo resources '$lang'..."

            ty=`bash $SCRIPTPATH/find_filter.sh $SOURCEPATH/MistakeTeam.Azana/Texto/$lang *.txt`
            wd=""
            for str in ${ty[@]}; do
                urw=${str##*/}
                wd+="$str,$SOURCEPATH/MistakeTeam.Azana/bin/Debug/net6.0/resources/$lang/${urw%.*}.resources "
            done
            echo $wd

            resgen -useSourcePath -compile $wd
        fi
        
        cd ../..
    fi
done
