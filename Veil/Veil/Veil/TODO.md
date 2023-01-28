# TODO

## New Modules

- Route Planning
- CCTV
- Live and historical telemetry
- Photo and Video Library, geotagged.
- Voice Commands
- Financial

## Dashboard

- This will primarily be used fullscreen in-van, so we need 
  as much-live updating as we can.

  Current List of items that we want on the dashboard in the 100vh:
	- Map (Live Updates the position, should be quite easy to do w/ callbacks and leaflet 'moveTo' functions)
	- Time (timezones, (grabbing timezone from coords?))
	- Weather of pos
	- LIVE Telemetry
	- Daily budget?


## Weather
- Weather use the location on the most recent data, and show those coords on the map. 
- Save each weather result we pull from server, into json files. Manage these files, 
  deleting old ones and using 'nearby' weather results if we have a recent forecast stored.
- Searchable list of locations (cities, etc.) with their coords, for offline usage, this could be
  used in Maps also to 'goto' that location.
- Edit the tempuratures on tempurartures graph to have the time in HH:mm format.


## Stock 

- Figure out what data we need, add to various classes.
- Implement, groupable, sortable, datagrids (mudblazor looks rly good for this.)


## Literature

- Present data nicely.
- We have a complete working search and database functionality, just need to get it to look nice.

## App Integration

Two apps offer community reviews and spot hunting for places to park, grab water etc.
1. Park4Night
2. SearchForSites

Implementing these as pulling from an api would be excellent.


## Testing 

- Start
