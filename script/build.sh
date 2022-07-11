#!/bin/bash

#Mistake Team (R) Algo ¯\_(ツ)_/¯
#Copyright (C) Mistake Team. Todos os direitos reservados.


SOURCEPATH="$(cd -- "../$(dirname "${BASH_SOURCE[0]}")" >/dev/null 2>&1 ; pwd -P)"
SCRIPTPATH="$(cd -- "$(dirname "${BASH_SOURCE[0]}")" >/dev/null 2>&1 ; pwd -P)"
BUILDPATH="$SOURCEPATH/build"


eval $(bash parse_yaml.sh $SOURCEPATH/mistaketeam.$1/config.yaml config_)

mkdir -p $BUILDPATH/debug

echo X----------------------X

if [[ -n $config_namespace ]]
then
    projectpath=$SOURCEPATH/$config_namespace
    respath=$BUILDPATH/debug/resources
    
    if [ -d $projectpath ]
    then
        
        case "$config_target" in
            "exe")
                echo "Construindo executável '$config_name'"
            ;;
            "library")
                echo "Construindo biblioteca '$config_name'"
            ;;
            *)
                echo "Algo deu errado."
            ;;
        esac
        
        
        wd=`bash $SCRIPTPATH/find_filter.sh $projectpath *.cs`
        rd=`bash $SCRIPTPATH/find_filter.sh $respath *.resources`

        rf=""
        if [[ -n $config_references ]]
        then
            arrIN=(${config_references// / })
            for str in ${arrIN[@]}; do
                rf+="/r:$BUILDPATH/debug/$str "
            done
        fi

        if [[ $config_resources ]]
        then
            rf+="/res:$rd "
        fi

        csc /nowarn:1591 $rf /t:$config_target /out:$BUILDPATH/debug/$config_outname /nologo /doc:$BUILDPATH/debug/${config_outname%.*}.xml $wd
    fi
fi
