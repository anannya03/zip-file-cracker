import zipfile

wordlist = 'rockyou.txt'
zip_file = 'secret.zip'
flag = False

# initialize the Zip File object
zip_file = zipfile.ZipFile(zip_file)

# count the number of words in this wordlist
num_words = len(list(open(wordlist, "rb")))

# print the total number of passwords
print "Total passwords to test: " + str(num_words)

#try the passwords one by one against the zip file
with open(wordlist, "rb") as wordlist:
	for word in wordlist:
		print 'trying password: ' + word
		try:
			zip_file.extractall(pwd=word.strip())
		except Exception:
			continue
		else:
			print "[+] Password found: " + word.decode().strip()
			flag = True
			break

if(flag == True):
	print "Succesful"
else:
	print "[!] Password not found, try other wordlist."