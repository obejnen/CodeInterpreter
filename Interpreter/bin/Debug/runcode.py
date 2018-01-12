def renderLoop(count, text):
	result = ""
	for i in range(count):
		result += text
	return result
output = ""
import sys;
def redirect(text):
	original = sys.stdout
	sys.stdout = open('c:/Users/obejn/source/repos/Interpreter/Interpreter/bin/Debug/output.txt', 'w')
	print(text)
	sys.stdout = original
output += "" + "{0}".format(renderLoop(2, "{0}".format("<" + "{0}".format(renderLoop( 5 , "{0}".format("*"))) + ">"))) + "";redirect(output);