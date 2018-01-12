def renderLoop(count, text)result = '';count.times{ result += text };result;end
def redirect(text)file = File.open("output.txt", "w");file.puts(text);file.close;end
output = ""
output += "" + "#{5+5}" + "";redirect(output)