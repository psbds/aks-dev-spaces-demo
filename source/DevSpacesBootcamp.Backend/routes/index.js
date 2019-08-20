const express = require('express');
const router = express.Router();

/* GET home page. */
router.get('/', (req, res) => {
  res.render('index', { title: 'Express' });
});

router.get('/data', (req, res) => {

  var data = [
    "Orgrimmar",
    "Thunderbluff",
    "Undercity",
    "Silvermoon"
  ]

  res.status(200).send(data);
});

module.exports = router;
