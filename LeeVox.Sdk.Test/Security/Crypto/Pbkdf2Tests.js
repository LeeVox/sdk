const crypto = require('crypto');
var result = '';

console.log("PBKDF2 - SHA1");

result = crypto.pbkdf2Sync('', 'random-salt', 10000, 20, 'sha1');
console.log(result.toString('hex'));

result = crypto.pbkdf2Sync('123456', 'random-salt', 100000, 20, 'sha1');
console.log(result.toString('hex'));

result = crypto.pbkdf2Sync('Đây là UniCode!', 'random-salt', 1000000, 20, 'sha1');
console.log(result.toString('hex'));

console.log("PBKDF2 - SHA256");

result = crypto.pbkdf2Sync('', 'random-salt', 10000, 32, 'sha256');
console.log(result.toString('hex'));

result = crypto.pbkdf2Sync('123456', 'random-salt', 100000, 32, 'sha256');
console.log(result.toString('hex'));

result = crypto.pbkdf2Sync('Đây là UniCode!', 'random-salt', 1000000, 32, 'sha256');
console.log(result.toString('hex'));

console.log("PBKDF2 - SHA512");

result = crypto.pbkdf2Sync('', 'random-salt', 10000, 64, 'sha512');
console.log(result.toString('hex'));

result = crypto.pbkdf2Sync('123456', 'random-salt', 100000, 64, 'sha512');
console.log(result.toString('hex'));

result = crypto.pbkdf2Sync('Đây là UniCode!', 'random-salt', 1000000, 64, 'sha512');
console.log(result.toString('hex'));