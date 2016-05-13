NAME
	Geocoder

SYNOPSIS
	geocoder [-t] table...

DESCRIPTION
	Geocoder is a command line utility that connects to the Where2Next database, checks for services without coordinate data, and then uses the Google Maps Geocoding API to find coordinates for those services.

OPTIONS
	-t	Run in test mode - only show the number of rows in each table that need fixing, do not make any changes to the database

TABLES
	Specify which tables you want the script to check/update as command parameters, seperated by a space if you wish to process more than one. If you are using the -t flag, it must come before any tables. You must provide the table name exactly as it is in the database. 

MAINTENANCE
	As this is very much a single purpose "in-house" tool, it is not especial;y configurable. The database connection details are hardcoded in the source, so if the database is migrated, the tool will need to be udpated with the relevant information and recompiled from source. Attention should be paid to the API key associated with the application - Google only allow 2500 free API calls per day. If there are no payment details associated with the API key in use, this tool will not function once that limit has been reached. If payment information has been associated with the key, requests beyond the limit cost USD$0.50 per 1000 requests. 

ACKNOWLEDGEMENTS
	This project uses the Geocoding.net library (https://github.com/chadly/Geocoding.net)

AUTHOR
	Jonathan Warner

