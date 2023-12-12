#!/bin/bash

dotnet build -c Release

packageDirectory=$(mktemp -d)
archiveFileName="NoiseSuppression.zip"

cp src/NoiseSuppression/bin/Release/netstandard2.1/NoiseSuppression.dll $packageDirectory/
cp {CHANGELOG.md,README.md,icon.png,LICENSE.txt,manifest.json} $packageDirectory/

pushd $packageDirectory

zip -r NoiseSuppression.zip *

popd

cp $packageDirectory/$archiveFileName ./
rm -r $packageDirectory
