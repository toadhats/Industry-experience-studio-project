NAME
	Geocoder - a script for maintaining geospatial information in the Where2Next database. 

SYNOPSIS
	geocoder [-t] table...

DESCRIPTION
	Geocoder is a command line utility that connects to the Where2Next database, checks for services without coordinate data, and then uses the Google Maps Geocoding API to find coordinates for those services.

OPTIONS
	-t	Run in test mode - only show the number of rows in each table that need fixing, do not make any changes to the database

TABLES
	Specify which tables you want the script to check/update as command parameters, seperated by a space if you wish to process more than one. If you are using the -t flag, it must come before any tables. You must provide the table name exactly as it is in the database. 

AUTHOR
	Jonathan Warner

