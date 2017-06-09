#!/bin/sh


while read line; do
	git rm $line
done < lala.txt