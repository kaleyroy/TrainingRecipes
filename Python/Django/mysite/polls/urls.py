from django.conf.urls import patterns,url
from polls import views

urlpatterns = patterns('',
    #eg: /polls/
    url(r'^$', views.index, name = 'index'),
    #eg: /polls/1
    url(r'^(?P<poll_id>\d+)/$', views.detail, name = 'detail'),
    #eg:
    url(r'^(?P<poll_id>\d+)/results/$', views.results, name = 'results'),
    #eg:
    url(r'^(?P<poll_id>\d+)/vote/$', views.vote, name = 'vote'),
)