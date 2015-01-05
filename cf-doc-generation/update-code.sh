#!/bin/bash

DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )

# Make sure libmysql.dll exists
if [ -e 'libmysql.dll' ] ; then
    echo "Can't find libmysql.dll. Make sure it's in your PATH."
fi

# Make sure mysql.exe exists
if [ -x 'mysql' ] ; then
    echo "Can't find the mysql client executable. Make sure it's in your PATH."
fi

# Generate Cloud Foundry API Doc templates
# gem version should be 2.3.0
# gem update --system 2.3.0

export TASKS=spec:api
export DB=mysql

# needs mysql connector from http://dev.mysql.com/get/Downloads/Connector-C/mysql-connector-c-6.1.5-win32.zip
# Make sure not to use a directory with spaces ' ' in it.
# bundle config build.mysql2 --with-mysql-dir="E:\Tools\mysql-connector-c-6.1.5-win32"
# TODO: vladi: make a subcommand for the setup part?
#bundle install --deployment --without development

export BUNDLE_GEMFILE=${DIR}/Gemfile-cf-docgen

cd ${DIR}/../cloud_controller_ng

# We can't run the db:create rake task, since it doesn't run mysql properly
`mysql -e "create database cc_test;" -u root --password=password`

mv -f ${DIR}/../cloud_controller_ng/spec/api/documentation/templates/rspec_api_documentation/html_example.mustache ${DIR}/html_example.mustache.bk
cp ${DIR}/html_example.mustache ${DIR}/../cloud_controller_ng/spec/api/documentation/templates/rspec_api_documentation/

bundle exec rake ${TASKS}

mv -f ${DIR}/html_example.mustache.bk ${DIR}/../cloud_controller_ng/spec/api/documentation/templates/rspec_api_documentation/html_example.mustache

# Delete existing auto-generated C# classes
rm -rf ${DIR}/../cf-net-sdk-pcl/Client/**

# Use codegen to generate C# classes
export BUNDLE_GEMFILE=${DIR}/../cf-sdk-builder/Gemfile
${DIR}/../cf-sdk-builder/bin/codegen --in ${DIR}/../cloud_controller_ng/doc/api/ --out ${DIR}/../cf-net-sdk-pcl/Client/ --language csharp --service cloudfoundry


