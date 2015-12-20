#!/bin/bash
#
# Linux 32-bit/64-bit

# Copyright (C) polynation games ltd - All Rights Reserved
# Unauthorized copying of this file, via any medium is strictly prohibited
# Proprietary and confidential
# Written by Christopher Redden, December 2013

# 64 Bit Version
mkdir -p linux/x86_64

cd luajit
make clean

make BUILDMODE=static CC="gcc -fPIC -m64"
cp src/libluajit.a ../linux/libluajit.a

cd ../pbc/
make clean
make BUILDMODE=static CC="gcc -fPIC -m64"
cp build/libpbc.a ../linux/x86_64/libpbc.a

cd ../cjson/
make clean
make BUILDMODE=static CC="gcc -fPIC -m64"
cp build/libcjson.a ../linux/x86_64/libcjson.a

cd ..
gcc -fPIC \
	lua_wrap.c \
	pb.c \
	lpeg.c \
	pbc/binding/lua/pbc-lua.c \
	cjson/lua_cjson.c \
	sqlite/src/sqlite3.c \
	sqlite/lsqlite3.c \
	-o Plugins/x86_64/libulua.so -shared \
	-I./ \
	-Iluajit/src \
	-Ipbc \
	-Icjson \
	-Isqlite/src \
	-Wl,--whole-archive \
	linux/x86_64/libluajit.a \
	linux/x86_64/libpbc.a \
	linux/x86_64/libcjson.a \
	-Wl,--no-whole-archive -static-libgcc -static-libstdc++
