#!/bin/bash

# Mistake Team (R) Algo ¯\_(ツ)_/¯
# Copyright (C) Mistake Team. Todos os direitos reservados.

cd ..


case "$1" in
    "add")
        ut=""
        if [[ -z $2 ]]
        then
            ut="."
        fi

        git add $2
        
        git status
    ;;
    
    "commit")
        if [ -z $2 ]
        then
            echo "😅 Sem comentários não rola."
            exit 0
        fi

        git commit -m "$2"
    ;;
    
    "push")
        br=`git config branch.master.remote`
        if [[ br == "" ]]
        then
            #git remote add origin https://github.com/MistakeTeam/Azana
            git push -u -f origin master
        else
            git push -u -f
        fi
    ;;
    
    *)
        echo "😅 Esse comando não existe."
        exit 0
    ;;
esac

