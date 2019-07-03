const crypto = require('crypto');
const options = {N: 262144, r: 8, p: 1, maxmem: 1024*1024*1024};
var result = '';

result = crypto.scryptSync('', 'random-salt', 32, options);
console.log(result.toString('hex'));

result = crypto.scryptSync('123456', 'random-salt', 32, options);
console.log(result.toString('hex'));

result = crypto.scryptSync('Đây là UniCode!', 'random-salt', 32, options);
console.log(result.toString('hex'));