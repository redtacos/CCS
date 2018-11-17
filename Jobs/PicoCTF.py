# Cront expression 0 */30 * * * *

import sys

sitepackage = 'D:\home\site\wwwroot\env\Lib\site-packages'
sys.path.append(sitepackage)

import requests
import datetime
import json
import os

print('Starting ...')

file_path = os.path.join(os.environ['APPSETTING_SCOREBOARD_PATH'], 'picoctf', 'usernames.json')
print('Reading wanted usernames from file ' + file_path)

with open(file_path, 'r') as infile:
    wantedUsernames = json.load(infile)
print('Looking for the following usernames : ' + json.dumps(wantedUsernames))

r = requests.Session()

request = r.get('https://2018game.picoctf.com/api/stats/scoreboard')
message = request.json()
globalScoreboardPages = message['data']['global']['pages']
print('Scoreboard has ' + str(globalScoreboardPages) + ' pages')

playerScoresFound = []
pageIndex = 0
for pageIndex in range(globalScoreboardPages + 1):
    request = r.get('https://2018game.picoctf.com/api/stats/scoreboard/global/' + str(pageIndex))
    message = request.json()

    for positionInPage, player in enumerate(message['data']):
        if(player['name'] in wantedUsernames):
            player['scoreboard_page'] = pageIndex
            player['scoreboard_position'] = (pageIndex - 1) * 50 + positionInPage + 1
            playerScoresFound.append(player)

    if(len(playerScoresFound) == len(wantedUsernames)):
        break
print('Scanned ' + str(pageIndex) + ' pages')

result = {}
result['last_fetch_time'] = str(datetime.datetime.now().isoformat())
result['player_scores'] = playerScoresFound
print('Found ' + str(len(playerScoresFound)) + ' out of ' + str(len(wantedUsernames)) + ' players!')

file_path = os.path.join(os.environ['APPSETTING_SCOREBOARD_PATH'], 'picoctf', 'scoreboard.json')
print('Writing to file ' + file_path)

with open(file_path, 'w') as outfile:
    json.dump(result, outfile)
