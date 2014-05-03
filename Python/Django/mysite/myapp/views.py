from django.http import HttpResponse

# Hello function definition
def hello(request):
    return HttpResponse('Hello,guys! Thanks for visiting!')