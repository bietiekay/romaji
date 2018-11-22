# Romaji .NET command line tool

This tool can be used to convert any string from japanese kata (hiragana/katakana) to it's simple romaji form.

To achieve this the WanaKanaSharp library is used: https://github.com/caguiclajmg/WanaKanaSharp

## Usage
The tool can be run from the command line and provides two methods to be used:

### Method 1: Direct String to String
For this you simply run the tool with parameter -s and pass as the parameter the hiragana/katakana string you want to get converted to romaji. Please note that 
there will not be a newline character added.

Example:

    romaji -s "ひらがな"

Output: hiragana

### Method 2: Rename the contents of a directory from hiragana/katakana to romaji
Use the command line:

Example:

    romaji -d ./musik/
    
![Image](https://github.com/bietiekay/romaji/raw/master/Bildschirmfoto%20zu%202018-11-22%2016-10-08.png)
