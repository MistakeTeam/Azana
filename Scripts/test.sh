#!/bin/bash


#for caminho in src/Textos/*; do
   # if [ -d "$caminho" ]; then
        #lang="${caminho##*/}"
#    fi
#done


#myArray=(dr4.dll j9y.dll 7pk.dll 3eh.dll)
#for str in ${myArray[@]}; do
  #echo $str
#done


#shopt -s nullglob dotglob     # To include hidden files
#files=(src/*)
#if [ ${#files[@]} -gt 0 ]; then echo "huzzah"; fi

#for str in ${files[@]}; do
  #echo $str
#done


#ft=`find src`
#arrIN=(${ft// / })
#for str in ${arrIN.[@]}; do
#  echo $str
#done


#text1="'helo there.cs'"
#if [[ $text1 =~ ^\cs.*\'$ ]]; then
  #      echo "text1 match"
#else
   #     echo "text1 not match"
#fi

#text2="'hello babe.cs'"
#if [[ $text2 =~ /*.cs/ ]]; then
     #  echo "text2 match"
#else
    #    echo "text2 not match"
#fi




#case "jhuk.c" in *.c) echo Yes;; esac



#if [[ "ghb.bj trs.cs" == *.cs ]]
#then
#echo oi
#fi

#opk="kia:nsisi pwow:sjjs"
#echo "${opk##:*}"
#iju=("${opk//:/ }")
#echo ${iju[@]}

#declare -A options
#arrIN=($@)
#op=("/ksks")
#for str in ${arrIN[@]}; do
    #if [[ "${op[@]}" =~ "${str%:*}" ]]
    #then
        #iju=("${str///}")
        #echo $iju
        #echo $str
        #options[${iju%:*}]=${str#*:}
    #fi
#done

#echo ${options[ksks]}
#echo ${options[sjjs]}





SOURCEPATH="$(cd -- "../$(dirname "$0")" >/dev/null 2>&1 ; pwd -P)"
SCRIPTPATH="$(cd -- "$(dirname "$0")" >/dev/null 2>&1 ; pwd -P)"
BUILDPATH="$(cd -- "$(dirname "${BASH_SOURCE[0]}")" >/dev/null 2>&1 ; pwd -P)"
echo $SOURCEPATH
echo $SCRIPTPATH
echo $BUILDPATH
echo "$(cd -- "$(dirname "${BASH_SOURCE[0]}")")"

cd ../build/debug
PO1="$(cd -- "$(dirname "${BASH_SOURCE[0]}")" >/dev/null 2>&1 ; pwd -P)"
echo $PO1




