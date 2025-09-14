from flask import Flask, render_template, request, abort
import parser
from exceptions import *

app = Flask(__name__, template_folder='templates')

@app.route("/")
def initial_page():
    return render_template('index.html')

@app.route("/getGamePage", methods=["GET"])
def get_game_page():
    name = request.args.get('name')
    try:
        url = parser.GetPageUrlById(name)
        return parser.GetGamePageFromUrl(url)
    
    except GameNotFoundException:
        abort(404)

# app.run(debug=True)
app.run()