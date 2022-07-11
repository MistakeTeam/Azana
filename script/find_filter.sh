#!/bin/bash

# Mistake Team (R) Algo ¯\_(ツ)_/¯
# Copyright (C) Mistake Team. Todos os direitos reservados.

if [ ! -z $1 ]
then
    wd=$1
    filesWD=()
    rv=`find $wd`
    arrJK=(${rv// / })
    for str in ${arrJK[@]}; do
        if [ ! -z $2 ] && [[ $str == $2 ]] || [ -z $2 ]
        then
            filesWD+="$str "
        fi
    done

    echo $filesWD
fi
