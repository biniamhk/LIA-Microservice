

	function sanitize(string) {
		//removes any non-allowed characters from input string and returns the result:
		const map = {
			'&': '',
			'<': '',
			'>': '',
			'"': '',
			"'": '',
			"/": '',
		};
		const reg = /[&<>"'/]/ig;
		if (string.length > 0) {return string.replace(reg, (match)=>(map[match]));}
		return string;
	}

	module.exports = sanitize;