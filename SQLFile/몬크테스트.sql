create table access_log
(
	seq int identity(1,1) not null primary key,
	ymd varchar(8) not null,
	cnt int default 0
)

create table access_list
(
	seq int identity(1,1) not null primary key,
	user_ip varchar(25) not null,
	cre_date datetime default getdate()	
)



create table card_main
(
	seq int identity(1,1) not null primary key,
	card_level char(1) not null default '1', -- 0:legend 1:epic 
	card_name varchar(200) not null,
	card_passive1 varchar(200) null,
	card_passive2 varchar(200) null,
	card_basic_health int default 0,
	card_basic_strong1 int default 0,
	card_basic_defense int default 0,
	card_basic_strong2 int default 0,		
	card_etc varchar(3000) null,
	card_effect_attack decimal(4,3) default 0,
	card_effect_defense decimal(4,3) default 0,
	card_effect_defense_minus decimal(4,3) default 0
)

select * from card_main
order by card_level, case when card_etc = '레전드' then 0 when card_etc = '한정' then 1 when card_etc = '투기' then 2 else 9 end, card_name

select * from card_main
where card_level = '0'
order by 
case 
	when card_level = '0' then 0
	when card_level = '1' then 1
	when card_level = '2' then 4
	when card_level = '3' then 6
	when card_level = '4' then 8
	when card_level = '5' then 9
	when card_level = '6' then 10
	when card_level = '7' then 2
	when card_level = '8' then 3
	when card_level = '9' then 5
	when card_level = 'A' then 7	
else 99 end
, card_name

0 legend
1 epic
2 sss
3 ss
4 s
5 a
6 b
7 한정 epic
8 투기 epic
9 한정 sss
A 한정 ss

select card_level, MIN(card_name) from card_main group by card_level

select * from card_main

insert into card_main values
('1', '발키르잔', '일반공격피해 1750', '체력 3750', 3600, 810, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '클라우디아공주', '일반공격피해 1250', '체력 6250', 3600, 810, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '레지나루노', '체력 6250', '카드 공격력 250', 3600, 510, 1875, 112, '일반', 0, 0, 0)

insert into card_main values
('0', '그라시아', '매턴 3000씩 피해', '방어 1250', 5600, 560, 1200, 122, '레전드', 0, 0, 0)

insert into card_main values
('0', '레티르', '일반공격피해반사 33%', '기술피해 20%', 3800, 560, 2100, 122, '레전드', 0.2, 0, 0.33)

insert into card_main values
('0', '아스타로트', '전투시작시 12800 피해', '모든공격피해 10%', 3800, 920, 1200, 122, '레전드', 0, 0, 0.10)

insert into card_main values
('0', '알폰스', '일반공격시 30% 만큼 흡혈', '모든기술효과 15%', 5600, 560, 1200, 122, '레전드', 0.15, 0.15, 0)

insert into card_main values
('0', '제롬올렌더', '공격시 방어 100%만큼 추가피해', '', 3800, 560, 2100, 122, '레전드', 0, 0, 0)

insert into card_main values
('7', '광기의마녀폴른', '모든기술효과 20%', '일반공격피해 16.8%', 3600, 510, 1075, 172, '한정', 0.2, 0.2, 0)

insert into card_main values
('7', '김첨지네셋째딸', '일반공격피해 15%', '공격력 1250', 3600, 810, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('7', '로제산타', '모든기술효과 20%', '공격피해감소 17.3%', 3600, 510, 1075, 172, '한정', 0.2, 0.2, 0.173)

insert into card_main values
('7', '로즈데라', '일반공격시 30% 추가관통피해', '', 3600, 810, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('7', '루시펠', '공격시 50%확률로 5000 추가피해', '', 3600, 510, 1075, 172, '한정', 0, 0, 0)

insert into card_main values
('7', '성탄절의프레이즈', '모든기술효과 20%', '공격력 1500', 3600, 810, 1075, 112, '한정', 0.2, 0.2, 0)

insert into card_main values
('7', '송판서네둘째딸', '공격시 2500 추가피해', '', 5100, 510, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('7', '시월의프레이즈', '공격피해감소 15%', '체력 7000', 5100, 510, 1075, 112, '한정', 0, 0, 0.15)

insert into card_main values
('7', '어사드라콘', '기술피해 23%', '모든공격피해 14.6%', 3600, 510, 1825, 112, '한정', 0.376, 0, 0)

insert into card_main values
('7', '인페르나', '연속공격시 70% 피해', '', 3600, 810, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('7', '저승차사고도령', '모든공격피해 13%', '공격력 1400', 3600, 810, 1075, 112, '한정', 0.13, 0, 0)

insert into card_main values
('7', '티켓삐에로', '공격피해감소 15%', '모든공격피해 15.6%', 5100, 510, 1075, 112, '한정', 0.156, 0, 0.15)

insert into card_main values
('7', '푸른털의청마', '모든공격피해 18.2%', '체력 4500', 5100, 510, 1075, 112, '한정', 0.182, 0, 0)

insert into card_main values
('7', '푸이20세', '일반공격피해 1250', '공격피해감소 15%', 3600, 510, 1825, 112, '한정', 0, 0, 0.15)

insert into card_main values
('7', '푸이6세', '공격피해감소 15%', '체력 6250', 3600, 810, 1075, 112, '한정', 0, 0, 0.15)

insert into card_main values
('7', '해변의바바라', '체력 6250', '카드공격력 280', 3600, 510, 1075, 172, '한정', 0, 0, 0)

insert into card_main values
('7', '해변의클라우디아', '체력 6250', '공격력 1400', 3600, 810, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('7', '힐다', '모든기술효과 20%', '모든공격피해 14.6%', 5100, 510, 1075, 112, '한정', 0.346, 0.2, 0)

insert into card_main values
('7', '니콜라스', '모든공격피해 15.6%', '방어력 3000', 5100, 510, 1075, 112, '한정', 0.156, 0, 0)

insert into card_main values
('1', '지도자드라칸', '카드공격력 400', '모든공격피해 6%', 3600, 510, 1075, 172, '일반', 0.06, 0, 0)

insert into card_main values
('8', '로테만', '공격력 2000', '모든공격피해 6%', 3600, 810, 1075, 112, '투기', 0.06, 0, 0)

insert into card_main values
('8', '롤랑', '모든공격피해 15.6%', '일반공격피해 12%', 5100, 510, 1075, 112, '투기', 0.156, 0, 0)

insert into card_main values
('8', '무닌', '공격력 2500', '', 5100, 510, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('8', '시그룬', '방어력 6625', '', 3600, 510, 1825, 112, '투기', 0, 0, 0)

insert into card_main values
('8', '유릭투스', '일반공격피해 2500', '', 3600, 510, 1075, 172, '투기', 0, 0, 0)

insert into card_main values
('8', '카르가스', '모든기술효과 40%', '', 5100, 510, 1075, 112, '투기', 0.4, 0.4, 0)

insert into card_main values
('8', '패트리샤', '모든공격피해 26%', '', 3600, 810, 1075, 112, '투기', 0.26, 0, 0)

insert into card_main values
('8', '피오라', 'HP가 60% 이하일때 일반공격피해 60%', '', 5100, 510, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('8', '헤레이스', '체력 12500', '', 3600, 510, 1075, 172, '투기', 0, 0, 0)

insert into card_main values
('8', '황녀바바라', '카드공격력 500', '', 3600, 510, 1825, 112, '투기', 0, 0, 0)

insert into card_main values
('8', '샨드라', '모든공격피해 7.8%', '일반공격피해 1900', 5100, 510, 1075, 112, '투기', 0.078, 0, 0)

---------------

insert into card_main values
('7', '산타드라', '방어력 25%', '일반공격피해 15%', 3600, 510, 1075, 172, '한정', 0, 0, 0)

insert into card_main values
('1', '고대의베르실', '방어력 3125', '카드공격력 250', 5100, 510, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '고대의쿠아크란', '공격피해감소 30%', '', 3600, 810, 1075, 112, '일반', 0, 0, 0.3)

insert into card_main values
('1', '고대의트리아크', '체력 6250', '방어력 3125', 3600, 810, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '고대의펠렁', '일반공격피해 30%', '', 5100, 510, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '고라', '일반공격피해 15%', '일반공격피해 1250', 5100, 510, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '그렌가르', '일반공격피해 1250', '카드공격력 250', 3600, 510, 1075, 172, '일반', 0, 0, 0)

insert into card_main values
('1', '나비여왕블린데라', '공격피해감소 21%', '카드공격력 150', 3600, 510, 1825, 112, '일반', 0, 0, 0.21)

insert into card_main values
('1', '누아카', '모든공격피해 13%', '공격피해감소 15%', 3600, 810, 1075, 112, '일반', 0.13, 0, 0.15)

insert into card_main values
('1', '대마법사냥코', '기술피해 46%', '', 3600, 510, 1075, 172, '일반', 0.46, 0, 0)


---------------------------------

insert into card_main values
('1', '도르드라콘', '방어력 20%', '공격력 30%', 3600, 810, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '로제타', '모든공격피해 13%', '일반공격피해 1250, 공격력 300', 3600, 810, 1075, 112, '일반', 0.13, 0, 0)

insert into card_main values
('1', '멜라웬', '공격피해감소 24%', '방어력 1250', 3600, 510, 1825, 112, '일반', 0, 0, 0.24)

insert into card_main values
('1', '박쥐여왕릴리아카', '일반공격피해 21%', '체력 3750', 3600, 510, 1075, 172, '일반', 0, 0, 0)

insert into card_main values
('1', '불드레이크', '방어력 25%', '기술피해 23%', 3600, 810, 1075, 112, '일반', 0.23, 0, 0)

insert into card_main values
('1', '브류나드', '모든공격피해 18.2%', '체력 3750', 5100, 510, 1075, 112, '일반', 0.182, 0, 0)

insert into card_main values
('1', '스칼렛', '모든공격피해 18.2%', '체력 3750', 5100, 510, 1075, 112, '일반', 0.182, 0, 0)

insert into card_main values
('1', '브리실다', '공격피해감소 15%', '공격력 1250', 5100, 810, 1075, 112, '일반', 0, 0, 0.15)

insert into card_main values
('1', '블레스크', '모든공격피해 13%', '카드공격력 250', 5100, 510, 1075, 112, '일반', 0.13, 0, 0)

insert into card_main values
('1', '시어러', '체력 3750', '공격력 1750', 3600, 810, 1075, 112, '일반', 0, 0, 0)


insert into card_main values
('1', '웰드킨장로', '일반공격피해 15%', '카드공격력 25%', 5100, 510, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '이멜다', '모든공격피해 13%', '체력 6250', 3600, 810, 1075, 112, '일반', 0.13, 0, 0)


insert into card_main values
('1', '챠바나', '모든공격피해 20.8%', '카드공격력 100', 3600, 510, 1075, 172, '일반', 0.208, 0, 0)

insert into card_main values
('1', '캘시퍼', '모든공격피해 13%', '공격력 1250', 5100, 510, 1075, 112, '일반', 0.13, 0, 0)

insert into card_main values
('1', '크리스탈', '일반공격피해 24%', '카드공격력 100', 5100, 510, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '크림킨드', '일반공격피해 15%', '기술피해 23%', 3600, 510, 1075, 172, '일반', 0.23, 0, 0)



insert into card_main values
('1', '트리아크', '일반공격피해 15%', '공격피해감소 15%', 5100, 510, 1075, 112, '일반', 0, 0, 0.15)

insert into card_main values
('1', '파괴신의배우자', '공격력 1250', '방어력 3125', 3600, 810, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '펠렁', '공격피해감소 15%', '기술피해 23%', 3600, 810, 1075, 112, '일반', 0.23, 0, 0.15)

insert into card_main values
('1', '푸이13세', '일반공격피해 18%', '공격력 20%', 5100, 510, 1075, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '프레이즈', '체력 2500', '공격피해감소 24%', 5100, 510, 1075, 112, '일반', 0, 0, 0.24)

insert into card_main values
('1', '프리마베라', '일반공격피해 1250', '방어력 3125', 3600, 510, 1825, 112, '일반', 0, 0, 0)

insert into card_main values
('1', '힐렌', '모든공격피해 18.2%', '방어력 1875', 3600, 510, 1075, 172, '일반', 0.182, 0, 0)

insert into card_main values
('7', '파도법사아이린', '모든공격피해 15.6%', '카드공격력 250', 3600, 510, 1075, 172, '한정', 0.156, 0, 0)

insert into card_main values
('7', '레드크리스탈', '공격력 1250', '모든공격피해 15.6%', 3600, 810, 1075, 112, '한정', 0.156, 0, 0)

insert into card_main values
('7', '베네딕트', '공격피해감소 21%', '카드공격력 200', 3600, 510, 1825, 112, '한정', 0, 0, 0.21)

insert into card_main values
('8', '카자미르', '체력 7000', '카드 공격력 250', 5100, 510, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('7', '하모니', '카드공격력 550', '', 3600, 510, 1075, 172, '한정', 0, 0, 0)

insert into card_main values
('1', '스텔라노어', '모든공격피해 13%', '체력 7000', 3600, 810, 1075, 112, '일반', 0.13, 0, 0)

insert into card_main values
('8', '무칼리', '일반공격피해 1900', '체력 3750', 3600, 810, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('7', '성기사셰릴', '일반공격피해 18%', '카드공격력 250', 5100, 510, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('7', '사마라', '공격피해감소 24%', '방어력 1875', 3600, 510, 1825, 112, '한정', 0, 0, 0.24)

insert into card_main values
('7', '소피', '일반공격피해 2750', '', 3600, 810, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('8', '해골기사바란', '일반공격피해 16.8%', '일반공격피해 1250', 5100, 510, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('7', '마법교사베네딕트', '모든공격피해 23.4%', '체력 2500', 5100, 510, 1075, 112, '한정', 0.234, 0, 0)

insert into card_main values
('7', '로자리안', '모든공격피해 29%', '', 5100, 510, 1075, 112, '한정', 0.29, 0, 0)

insert into card_main values
('1', '루아나프라', '모든공격피해 13%', '일반공격피해 1400', 3600, 810, 1075, 112, '일반', 0.13, 0, 0)

insert into card_main values
('7', '꼬마마녀크랜베리', '일반공격피해 24%', '체력 3750', 3600, 510, 1075, 172, '한정', 0, 0, 0)

insert into card_main values
('8', '쉬렌', '체력 7000', '방어력 3125', 5100, 510, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('7', '동백', '공격시 40%확률로 10000 추가피해', '', 5100, 510, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('7', '마키아', '공격력 2750', '', 3600, 810, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('7', '당근술사케로티', '기술피해 50.6%', '', 5100, 510, 1075, 112, '한정', 0.506, 0, 0)

insert into card_main values
('7', '삼계푸이', '공격피해감소 33%', '', 5100, 510, 1075, 112, '한정', 0, 0, 0.33)

insert into card_main values
('8', '볼칸', '방어력 3125', '카드공격력 280', 3600, 510, 1075, 172, '투기', 0, 0, 0)

insert into card_main values
('7', '해변의로제타', '전투시작시 10000 피해', '', 3600, 810, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('7', '해변의하모니', '모든공격피해 7.8%', '체력 5150, 카드공격력 206', 5100, 510, 1075, 112, '한정', 0.09, 0, 0)

insert into card_main values
('8', '타히티', '공격력 1400', '체력 6250', 5100, 510, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('7', '숲의무녀폴리나', '모든기술효과 45%', '', 5100, 510, 1075, 112, '한정', 0.45, 0.45, 0)

insert into card_main values
('7', '베아트리체', '일반공격시 25% 만큼 흡혈 ', '', 5100, 510, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('1', '심해의루니아', '공격피해감소 16.8%', '방어력 3125', 3600, 510, 1825, 112, '일반', 0, 0, 0.168)

insert into card_main values
('7', '가을의루아나프라', 'HP가 70% 이하일때 일반공격피해 60%', '', 5100, 510, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('7', '칸칸슬레', '연속공격시 피해 77%', '', 5100, 510, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('8', '아리아', '일반공격피해 15%', '카드공격력 28%', 5100, 510, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('7', '용병왕마르칸', '공격력 1400', '일반공격피해 1400', 3600, 810, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('7', '죽음의마녀에스텔', '매턴 2300의 피해', '', 5100, 510, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('8', '이그니스', '일반공격피해 15%', '공격력 1400', 3600, 810, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('7', '모르간', '일반공격피해반사 25%', '', 3600, 510, 1825, 112, '한정', 0, 0, 0.25)

insert into card_main values
('7', '제피로스', '체력 14000', '', 5100, 510, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('8', '피에트로', '기술피해 25.8%', '모든공격피해 13.0%', 5100, 510, 1075, 112, '투기', 0.388, 0, 0)

insert into card_main values
('8', '인도자엘레인', '공격피해감소 16.8%', '모든공격피해 13%', 3600, 510, 1825, 112, '투기', 0.13, 0, 0.168)

insert into card_main values
('7', '성탄절의루디', '방어력 7000', '', 3600, 510, 1825, 112, '한정', 0, 0, 0)

insert into card_main values
('7', '성탄절의요정왕', '공격시 방어 83.3%만큼 추가피해', '', 5100, 510, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('8', '비운의왕녀루이젤', '공격력 28%', '공격력 1250', 3600, 810, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('7', '파동술사쟈카레', '공격력 2800', '', 5100, 510, 1075, 112, '한정', 0, 0, 0)

--insert into card_main values
--('7', '파동술사쟈카레(이벤트)', '공격력 3800', '', 5100, 510, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('7', '페렐로롯시에', '', '', 5100, 510, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('8', '아르키피라타', '공격피해감소 16.8%', '체력 6250', 3600, 510, 1825, 112, '투기', 0, 0, 0.168)

insert into card_main values
('7', '복받을거양', '체력 55%', '방어력 3500', 5100, 510, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('7', '흰나비블린데라', '카드공격력 560' , '', 3600, 510, 1075, 172, '한정', 0, 0, 0)

--insert into card_main values
--('7', '흰나비블린데라(이벤트)', '카드공격력 760' , '', 3600, 510, 1075, 172, '한정', 0, 0, 0)

insert into card_main values
('8', '아라네아', '모든공격피해 20.8%', '공격력 650', 5100, 510, 1075, 112, '투기', 0.208, 0, 0)

insert into card_main values
('7', '트윙클', '모든공격피해 29%', '', 5100, 510, 1075, 112, '한정', 0.29, 0, 0)

insert into card_main values
('7', '벚꽃무녀폴리나', '체력 4950', '일반공격피해 2310', 3600, 810, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('8', '레오나', '일반공격피해 1500', '방어력 3750', 3600, 510, 1825, 112, '투기', 0, 0, 0)

insert into card_main values
('7', '브린힐트', '공격피해감소 24%', '체력 6500', 3600, 510, 1825, 112, '한정', 0, 0, 0.24)

insert into card_main values
('7', '클라우디아교장', '공격피해감소 30%', '방어력 2000', 3600, 510, 1825, 112, '한정', 0, 0, 0.30)

insert into card_main values
('8', '튜톤대형골렘', '공격력 750', '공격력 45%', 3600, 810, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('8', '싱클레어', '일반공격시 27.5% 추가관통피해', '', 5100, 510, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('7', '샨드리스', '카드공격력 600', '', 3600, 510, 1075, 172, '한정', 0, 0, 0)

insert into card_main values
('7', '불사의마녀루드라', '공격력 1650', '모든공격피해 17.2%', 3600, 810, 1075, 112, '한정', 0.172, 0, 0)

insert into card_main values
('8', '타샤냐', '공격력 60%', '', 3600, 810, 1075, 112, '투기', 0, 0, 0)

insert into card_main values
('7', '해변의힐렌', '전투시작시 8000피해', '매턴 1833씩 피해', 5100, 510, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('8', '라트리스', '기술피해 40.5%', '체력 5000', 3600, 510, 1825, 112, '투기', 0.405, 0, 0)

insert into card_main values
('7', '피어난동백', '공격시 35%확률로 12000 추가피해', '', 5100, 510, 1075, 112, '한정', 0, 0, 0)

insert into card_main values
('8', '그리피오스', '방어력 2500', '카드공격력 440', 3600, 510, 1075, 172, '투기', 0, 0, 0)

insert into card_main values
('7', '흥겨운떡방아', '공격피해감소 26%', '체력 5150', 3600, 510, 1825, 112, '한정', 0, 0, 0.26)

insert into card_main values
('8', '벨루카스', '연속공격시 피해 65%', 'HP가 70% 이하일때 일반공격피해 35%', 5100, 510, 1075, 112, '투기', 0, 0, 0)


--------------------------------- SS
insert into card_main values
('A', '올해도솔로우거', '모든기술효과 32%', '', 4100, 410, 825, 92, '한정', 0.32, 0.32, 0)
insert into card_main values
('A', '오우린이', '공격력 32.5%', '', 4100, 410, 825, 92, '한정', 0, 0, 0)
insert into card_main values
('A', '더워우거', '체력 8750', '', 4100, 410, 825, 92, '한정', 0, 0, 0)
insert into card_main values
('A', '솔로우거', '일반공격피해 12%', '공격력 1000', 4100, 410, 825, 92, '한정', 0, 0, 0)

insert into card_main values
('A', '오우덜프', '일반공격피해 19.5%', '', 3100, 610, 825, 92, '한정', 0, 0, 0)
insert into card_main values
('A', '떡국장인오우쉐프', '공격력 1300', '방어력 825', 3100, 610, 825, 92, '한정', 0, 0, 0)

-------------------- 공
insert into card_main values
('3', '샤클', '공격력 810', '카드공격력 162', 3100, 610, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '드워프전사', '공격피해감소 11.7%', '공격력 6.5%', 3100, 610, 825, 92, '일반', 0, 0, 0.117)
insert into card_main values
('3', '아오백', '기술피해 29.9%', '', 3100, 610, 825, 92, '일반', 0.299, 0, 0)
insert into card_main values
('3', '눈의여왕', '방어력 32.5%', '', 3100, 610, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '쿠플린', '일반공격피해 813', '일반공격피해 813', 3100, 610, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '검은쿠란데라', '체력 16.3%', '카드공격력 16.3%', 3100, 610, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '마리나루노', '체력 2450', '카드공격력 228', 3100, 610, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '그랜드리전', '체력 32.5%', '', 3100, 610, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '신성엘프궁수', '체력 4050', '카드공격력 162', 3100, 610, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '공황의근위병', '일반공격피해 813', '방어력 2025', 3100, 610, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '드래킨', '공격력 810', '방어력 2025', 3100, 610, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '바이킹의후예', '공격력 16.3%', '방어력 16.3%', 3100, 610, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '예언자', '공격력 980', '카드공격력 130', 3100, 610, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '진홍의신성기사', '방어력 16.3%', '일반공격피해 9.8%', 3100, 610, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '튜톤멘서', '공격력 16.3%', '기술피해 15%', 3100, 610, 825, 92, '일반', 0.15, 0, 0)
insert into card_main values
('3', '하퓰라', '방어력 13%', '카드공격력 19.5%', 3100, 610, 825, 92, '일반', 0, 0, 0)

------------------- 방
insert into card_main values
('3', '키미안', '공격력 1050', '카드공격력 90', 3100, 410, 1325, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '뿔오우거', '공격력 16.3%', '체력 16.3%', 3100, 410, 1325, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '브로큰티어기사', '공격력 29.3%', '체력 800', 3100, 410, 1325, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '게슬론기사', '모든공격피해 16.9%', '', 3100, 410, 1325, 92, '일반', 0.169, 0, 0)
insert into card_main values
('3', '플레쉬몽거', '모든공격피해 8.5%', '공격력 810', 3100, 410, 1325, 92, '일반', 0.085, 0, 0)
insert into card_main values
('3', '웰드마스터', '방어력 3650', '체력 800', 3100, 410, 1325, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '게슬론마녀', '일반공격피해 15.6%', '공격력 310', 3100, 410, 1325, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '덴드로', '체력 16.3%', '일반공격피해 9.8%', 3100, 410, 1325, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '테라웜', '체력 8150', '', 3100, 410, 1325, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '성녀라비카', '체력 32.5%', '', 3100, 410, 1325, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '적염의장미', '일반공격피해 16.3%', '기술피해 15%', 3100, 410, 1325, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '전투골렘', '공격력 16.3%', '카드공격력 16.3%', 3100, 410, 1325, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '브린힐트크룸', '공격피해감소 15.6%', '체력 4250', 3100, 410, 1325, 92, '일반', 0, 0, 0.156)

------------------- 체
insert into card_main values
('3', '디아발라모히라', '공격력 32.5%', '', 4100, 410, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '성녀라비네스', '공격피해감소 19.5%', '', 4100, 410, 825, 92, '일반', 0, 0, 0.195)
insert into card_main values
('3', '레데라', '기술피해 15%', '공격피해감소 9.8%', 4100, 410, 825, 92, '일반', 0.15, 0, 0.098)
insert into card_main values
('3', '웰드킨', '일반공격피해 16.3%', '카드공격력 13%', 4100, 410, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '윈트루즈', '일반공격피해 813', '공격력 810', 4100, 410, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '서펜트로', '카드공격력 292', '방어력 3.3%', 4100, 410, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '프리즐', '모든공격피해 18.9%', '', 4100, 410, 825, 92, '일반', 0.189, 0, 0)

insert into card_main values
('3', '불의대사제', '방어력 16.3%', '카드공격력 16.3%', 4100, 410, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '안젤리카라', '방어력 2025', '카드공격력 162', 4100, 410, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '타락한제왕고라', '카드공격력 32.5%', '', 4100, 410, 825, 92, '일반', 0, 0, 0)
insert into card_main values
('3', '타타우루스', '체력 16.3%', '공격피해감소 9.8%', 4100, 410, 825, 92, '일반', 0, 0, 0.098)
insert into card_main values
('3', '튜톤티타누스', '체력 16.3%', '기술피해 15%', 4100, 410, 825, 92, '일반', 0.15, 0, 0)

------------------- 카

insert into card_main values
('3', '녹색쿠란데라', '방어력 16.3%', '기술피해 15%', 3100, 410, 825, 132, '일반', 0.15, 0, 0)
insert into card_main values
('3', '사도각성자', '공격력 1630', '', 3100, 410, 825, 132, '일반', 0, 0, 0)
insert into card_main values
('3', '배너후드', '공격력 19.5%', '카드공격력 15.6%', 3100, 410, 825, 132, '일반', 0, 0, 0)
insert into card_main values
('3', '드라마담', '공격력 810', '체력 4050', 3100, 410, 825, 132, '일반', 0, 0, 0)
insert into card_main values
('3', '하베스타', '방어력 32.5%', '', 3100, 410, 825, 132, '일반', 0, 0, 0)
insert into card_main values
('3', '아쿠아독스', '체력 2450', '공격력 1140', 3100, 410, 825, 132, '일반', 0, 0, 0)
insert into card_main values
('3', '오르칸', '체력 2450', '방어력 2850', 3100, 410, 825, 132, '일반', 0, 0, 0)
insert into card_main values
('3', '붉은쿠란데라', '체력 4050', '방어력 2025', 3100, 410, 825, 132, '일반', 0, 0, 0)
insert into card_main values
('3', '화염메두사', '카드공격력 16.3%', '기술피해 15%', 3100, 410, 825, 132, '단종', 0.15, 0, 0)
insert into card_main values
('3', '호리스사령관', '카드공격력 326', '', 3100, 410, 825, 132, '일반', 0, 0, 0)
insert into card_main values
('3', '대기록자', '체력 16.3%', '방어력 16.3%', 3100, 410, 825, 132, '일반', 0, 0, 0)
insert into card_main values
('3', '튜톤템플사령관', '방어력 4075', '', 3100, 410, 825, 132, '일반', 0, 0, 0)

--------------------------------- S
----------------------- 공
insert into card_main values
('4', '드래킨래키', '방어력 12.5%', '공격피해감소 7.5%', 2800, 520, 700, 82, '일반', 0, 0, 0.075)
insert into card_main values
('4', '미르드라콘', '방어력 12.5%', '공격력 12.5%', 2800, 520, 700, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '바위골렘', '체력 12.5%', '기술피해 11.5%', 2800, 520, 700, 82, '일반', 0.115, 0, 0)
insert into card_main values
('4', '번개위를걷는자', '방어력 3125', '', 2800, 520, 700, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '불의여사제', '체력 12.5%', '카드공격력 12.5%', 2800, 520, 700, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '상급음유시인', '카드공격력 25%', '', 2800, 520, 700, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '센타우루스', '체력 3150', '방어력 1575', 2800, 520, 700, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '암흑법사', '공격력 750', '체력 2500', 2800, 520, 700, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '유령들', '일반공격피해 7.5%', '공격피해감소 7.5%', 2800, 520, 700, 82, '일반', 0, 0, 0.075)
insert into card_main values
('4', '카데나', '카드공격력 12.5%', '일반공격피해 7.5%', 2800, 520, 700, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '컬킨기사', '공격력 12.5%', '기술피해 12.5%', 2800, 520, 700, 82, '일반', 0.125, 0, 0)
insert into card_main values
('4', '코넬리아', '공격력 12.5%', '방어력 12.5%', 2800, 520, 700, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '호리스귀족전사', '공격력 630', '방어력 1575', 2800, 520, 700, 82, '일반', 0, 0, 0)

--------------------- 방
insert into card_main values
('4', '룬골렘', '방어력 12.5%', '일반공격피해 7.5%', 2800, 360, 1100, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '메두사', '체력 12.5%', '공격피해감소 7.5%', 2800, 360, 1100, 82, '단종', 0, 0, 0.075)
insert into card_main values
('4', '멜로디', '방어력 12.5%', '체력 3150', 2800, 360, 1100, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '상급얼음법사', '공격력 25%', '', 2800, 360, 1100, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '엘프저격수', '카드공격력 12.5%', '공격피해감소 9%', 2800, 360, 1100, 82, '일반', 0, 0, 0.09)
insert into card_main values
('4', '진홍의기사', '방어력 12.5%', '기술피해 11.5%', 2800, 360, 1100, 82, '일반', 0.115, 0, 0)
insert into card_main values
('4', '쿠란데라', '기술피해 23%', '', 2800, 360, 1100, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '해골수집광', '공격력 500', '방어력 1875', 2800, 360, 1100, 82, '일반', 0, 0, 0)

----------------------- 체
insert into card_main values
('4', '게슬론대장공', '모든공격피해 6.5%', '체력 3150', 3600, 360, 700, 82, '일반', 0.065, 0, 0)
insert into card_main values
('4', '골든말리네사', '방어력 25%', '', 3600, 360, 700, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '기록자', '체력 12.5%', '일반공격피해 7.5%', 3600, 360, 700, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '말리네사', '방어력 12.5%', '카드공격력 12.5%', 3600, 360, 700, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '수호요정', '일반공격피해 7.5%', '기술피해 11.5%', 3600, 360, 700, 82, '일반', 0.115, 0, 0)
insert into card_main values
('4', '써큐네어', '체력 6250', '', 3600, 360, 700, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '암흑각성자', '체력 3150', '카드공격력 126', 3600, 360, 700, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '찢겨진천사', '공격력 630', '카드공격력 126', 3600, 360, 700, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '함정쥐', '카드공격력 25%', '', 3600, 360, 700, 82, '일반', 0, 0, 0)
insert into card_main values
('4', '흑표범', '공격력 500', '체력 3750', 3600, 360, 700, 82, '일반', 0, 0, 0)

------------------------ 카
insert into card_main values
('4', '광전사', '공격력 12.5%', '체력 12.5%', 2800, 360, 700, 114, '일반', 0, 0, 0)
insert into card_main values
('4', '늑대인간', '공격력 12.5%', '공격피해감소 7.5%', 2800, 360, 700, 114, '일반', 0, 0, 0.075)
insert into card_main values
('4', '다크리퍼', '공격력 630', '체력 3150', 2800, 360, 700, 114, '일반', 0, 0, 0)
insert into card_main values
('4', '당근술사', '일반공격피해 15%', '', 2800, 360, 700, 114, '일반', 0, 0, 0)
insert into card_main values
('4', '던전늑대인간', '카드공격력 250', '', 2800, 360, 700, 114, '일반', 0, 0, 0)
insert into card_main values
('4', '두번째코넬리아', '카드공격력 12.5%', '기술피해 11.5%', 2800, 360, 700, 114, '일반', 0.115, 0, 0)
insert into card_main values
('4', '상급하프술사', '기술피해 11.5%', '공격피해감소 7.5%', 2800, 360, 700, 114, '일반', 0, 0, 0.075)
insert into card_main values
('4', '엘프궁수', '공격력 12.5%', '카드공격력 12.5%', 2800, 360, 700, 114, '일반', 0, 0, 0)

insert into card_main values
('4', '오우거', '체력 12.5%', '방어력 12.5%', 2800, 360, 700, 114, '일반', 0, 0, 0)
insert into card_main values
('4', '좀비들', '방 1575', '카드공격력 126', 2800, 360, 700, 114, '일반', 0, 0, 0)

insert into card_main values
('4', '창을든소악마', '체력 25%', '', 2800, 360, 700, 114, '일반', 0, 0, 0)
insert into card_main values
('4', '튜톤불궁수', '공격피해감소 15%', '', 2800, 360, 700, 114, '일반', 0, 0, 0.15)
insert into card_main values
('4', '튜톤빙궁수', '공격력 1250', '', 2800, 360, 700, 114, '일반', 0, 0, 0)
insert into card_main values
('4', '튜톤타이탄', '공격력 12.5%', '일반공격피해 7.5%', 2800, 360, 700, 114, '일반', 0, 0, 0)

--------------------------- A
insert into card_main values
('5', '거대호박꽃', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '검의길을걷는자', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '고블린도둑', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '기가웜', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '더스키토', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '멧돼지병사', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '반건조미이라', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '붉은슬라임', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '브릭', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '산성살라맨더', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '설인28호', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '소악마', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '숲의정령', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '슬리더리쉬', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '신성나비요정', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '써큐버스', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '아리센', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '얼음법사', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '엘루이즈', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '영혼을마시는검', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '예니체리', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '요새골렘', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '용암해츨링', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '유니스', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '유령', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '음유시인', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '지옥개', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '창공해츨링', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '최면세이렌', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '침묵의요정', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '카자도르', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '카즈마이어', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '타락한근위병', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '타락한천사', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '토끼술사', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '튜톤검사', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '튜톤궁수', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '튜톤템플기사', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '파도법사', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '플라그엘리트전사', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '플리터피쉬', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '하프술사', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '화염법사', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '맹독전갈', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('5', '게슬론수호사제', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)

--------------------------- B
insert into card_main values
('6', '거대거미', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '거대쥐', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '견습파도법사', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '견습하프술사', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '나무정령', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '나무혼령', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '나비요정', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '늪지거대쥐', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '다이오니', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '멧돼지인간', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '미이라', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '사냥꾼', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '샐러맨더', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '슬라임', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '야생고블린', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '유니콘', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '좀비', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '축복받은세이렌', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '카즈미너', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '튜톤전사', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '티어헌터', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '플라그워리어', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '피를마시는검', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '흰색나비요정', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)
insert into card_main values
('6', '캘시퍼의눈', '', '', 0, 0, 0, 0, 'NON', 0, 0, 0)

----------------------------- SSS
insert into card_main values
('9', '잭스펜서', '공격력 1250', '체력 6250', 3300, 460, 950, 154, '한정', 0, 0, 0)
insert into card_main values
('9', '십이월의멜로디', '방어력 2500', '체력 5750', 3300, 460, 950, 154, '한정', 0, 0, 0)
insert into card_main values
('9', '호박을부리는유령', '모든공격피해 13%', '공격력 1250', 3300, 460, 950, 154, '한정', 0, 0, 0)
insert into card_main values
('9', '메두산타', '일반공격피해 12%', '공격피해감소 12%', 3300, 460, 1600, 102, '한정', 0, 0, 0.12)
insert into card_main values
('9', '파괴신의세컨드', '카드공격력 400', '', 3300, 460, 950, 154, '한정', 0, 0, 0)
insert into card_main values
('9', '용을부리는뱀', '', '', 3300, 460, 1600, 102, '한정', 0, 0, 0)
insert into card_main values
('9', '(드디어)오우마이갓', '체력 13250', '', 4600, 460, 950, 102, '한정', 0, 0, 0)


insert into card_main values
('2', '플렌티아', '공격피해감소 19.2%', '체력 8.0%', 4600, 460, 950, 102, '일반', 0, 0, 0.192)
insert into card_main values
('2', '쿠아크란', '공격력 20%', '공격피해감소 12%', 3300, 720, 950, 102, '일반', 0, 0, 0.12)
insert into card_main values
('2', '뉴라이너', '체력 20%', '카드공격력 20%', 3300, 460, 950, 154, '일반', 0, 0, 0)
insert into card_main values
('2', '드레드메이지', '카드공격력 40%', '', 3300, 720, 950, 102, '일반', 0, 0, 0)
insert into card_main values
('2', '디아발라드라히라', '카드공격력 20%', '공격피해감소 12%', 3300, 460, 1600, 102, '일반', 0, 0, 0.12)
insert into card_main values
('2', '성녀라빈느', '체력 20%', '일반공격피해 12%', 4600, 460, 950, 102, '일반', 0, 0, 0)
insert into card_main values
('2', '케트', '공격력 20%', '일반공격피해 12%', 3300, 460, 950, 154, '일반', 0, 0, 0)
--------------------------
insert into card_main values
('2', '그라디네', '카드공격력 20%', '일반공격피해 12%', 3300, 720, 950, 102, '일반', 0, 0, 0)
insert into card_main values
('2', '데스이터', '일반공격피해 24%', '', 3300, 720, 950, 102, '일반', 0, 0, 0)
insert into card_main values
('2', '펠레티', '공격피해감소 14.4%', '일반공격피해 9.6%', 3300, 720, 950, 102, '일반', 0, 0, 0.144)
insert into card_main values
('2', '알주리아레인저', '일반공격피해 24%', '', 3300, 720, 950, 102, '일반', 0, 0, 0)
insert into card_main values
('2', '얼음여왕', '방어력 20%', '공격피해감소 12%', 3300, 460, 1600, 102, '일반', 0, 0, 0.12)
insert into card_main values
('2', '웰드레인저', '체력 20%', '공격력 20%', 3300, 720, 950, 102, '일반', 0, 0, 0)
insert into card_main values
('2', '붉은달의마녀', '체력 20%', '공격피해감소 12%', 4600, 460, 950, 102, '일반', 0, 0, 0.12)
insert into card_main values
('2', '레이디나나', '공격력 1000', '방어력 2500', 3300, 460, 950, 154, '일반', 0, 0, 0)
insert into card_main values
('2', '지옥표범', '방어력 2500', '카드공격력 200', 3300, 460, 1600, 102, '일반', 0, 0, 0)
insert into card_main values
('2', '로비안전사', '일반공격피해 1000', '공격력 1000', 3300, 720, 950, 102, '일반', 0, 0, 0)
insert into card_main values
('2', '불사의마녀', '모든공격피해 16.6%', '공격피해감소 4.8%', 3300, 720, 950, 102, '일반', 0.166, 0, 0.048)
insert into card_main values
('2', '아홉번째성기사', '방어력 5000', '', 3300, 460, 1600, 102, '일반', 0, 0, 0)
insert into card_main values
('2', '베르실', '공격력 1000', '카드공격력 200', 4600, 460, 950, 102, '일반', 0, 0, 0)
insert into card_main values
('2', '데모니카라', '공격력 1000', '체력 5000', 3300, 720, 950, 102, '일반', 0, 0, 0)
insert into card_main values
('2', '펄페어리', '공격피해감소 24%', '', 3300, 460, 1600, 102, '일반', 0, 0, 0.24)
insert into card_main values
('2', '강철의신성기사', '체력 5000', '카드공격력 200', 3300, 460, 1600, 102, '일반', 0, 0, 0)
insert into card_main values
('2', '프레이즈의희망', '공격력 1800', '카드공격력 40', 3300, 720, 950, 102, '일반', 0, 0, 0)

insert into card_main values
('2', '푸른달의마녀', '공격력 2000', '', 3300, 720, 950, 102, '일반', 0, 0, 0)

insert into card_main values
('2', '브로큰티어여사제', '공격피해감소 21.6%', '공격력 200', 3300, 460, 1600, 102, '일반', 0, 0, 0.216)
insert into card_main values
('2', '에니드', '공격피해감소 12%', '공격력 1000', 3300, 460, 1600, 102, '일반', 0, 0, 0.12)
insert into card_main values
('2', '네툴리아', '체력 6000', '카드공격력 160', 3300, 460, 1600, 102, '일반', 0, 0, 0)
insert into card_main values
('2', '사샤', '일반공격피해 1000', '카드공격력 200', 3300, 460, 950, 154, '일반', 0, 0, 0)

select * from card_main

epic
3600, 510, 1075, 112
5100, 810, 1825, 172
sss
3300, 460, 950, 102
4600, 720, 1600, 154
ss
3000, 410, 825, 92
4100, 630, 1375, 136
s
2800, 360, 700, 82
3600, 520, 1100, 114


---------------------------------------

create table card_user
(
	seq int identity(1,1) not null primary key,
	u_id varchar(1000) not null,
	u_pwd varchar(255) not null,
	cre_date datetime default getdate()
)

select * from card_user where u_id = 'test' and u_pwd = 'test'
insert into card_user values ('test','test', GETDATE())

select * from card_battle_main a inner join card_user b on a.seq = b.seq
where a.card_name = '제롬올렌더'
order by ai_name desc, card_level desc, u_id

create table card_battle_main
(
	subseq int identity(1,1) not null primary key,
	seq int not null,
	battle_name varchar(2000),
	card_name varchar(200),
	card_level varchar(100),
	skill_1 varchar(200),
	skill_2 varchar(200),
	ai_name varchar(200),
	defense_per varchar(255),
	stat_health int default 0,
	stat_strong1 int default 0,
	stat_defense int default 0,
	stat_strong2 int default 0,
	sword1 float default 0,
	sword2 float default 0,
	sword3 float default 0,
	sword4 float default 0,
	sword5 float default 0,
	effect_atk float default 0,
	effect_def float default 0,
	cre_date datetime default getdate()
)

alter table card_battle_main
add sword1_s1 float default 0
alter table card_battle_main
add sword2_s1 float default 0
alter table card_battle_main
add sword3_s1 float default 0
alter table card_battle_main
add sword4_s1 float default 0
alter table card_battle_main
add sword5_s1 float default 0

alter table card_battle_main
add sword1_s2 float default 0
alter table card_battle_main
add sword2_s2 float default 0
alter table card_battle_main
add sword3_s2 float default 0
alter table card_battle_main
add sword4_s2 float default 0
alter table card_battle_main
add sword5_s2 float default 0

alter table card_battle_main
add sword1_s3 float default 0
alter table card_battle_main
add sword2_s3 float default 0
alter table card_battle_main
add sword3_s3 float default 0
alter table card_battle_main
add sword4_s3 float default 0
alter table card_battle_main
add sword5_s3 float default 0

select * from card_user
where u_id = 'usaki'

select * from card_battle_main a inner join 
(
	select seq from card_user
	where u_id = 'usaki'
) b on a.seq = b.seq
where ai_name is not null
order by subseq desc

select * from card_battle_main a inner join 
(
	select seq from card_user
	where u_id = 'usaki'
) b on a.seq = b.seq
and a.battle_name = ''
select * From card_battle_main where seq = 1
insert into card_battle_main values 
(1, '발키테스트', '발키르잔', '100', '불번', '화폭', '재주꾼1', 
30000, 6000, 5000, 400,
4000, 7500, 9000, 10000, 14000,
0, 0, getdate())

insert into card_battle_main
select
	seq, 
	'테스트',
	'공주',
	'100',
	'',
	'',
	'',
	30000, 6000, 5000, 400,
	4000, 7500, 9000, 10000, 14000,
	0, 0, GETDATE()
from card_user
where u_id = 'usaki'

create table card_AIList
(
	seq int identity(1,1) not null primary key,
	ai_name varchar(255) not null,
	first1 varchar(50) null,
	first2 varchar(50) null,
	first3 varchar(50) null,
	first4 varchar(50) null,
	cre_date datetime default getdate()
)

insert into card_AIList values ('공격형 재주꾼', '스킬1','공','스킬2','방', GETDATE())
insert into card_AIList values ('방어형 재주꾼', '스킬1','방','스킬2','공', GETDATE())
insert into card_AIList values ('일단 살아야지', '방','스킬1','스킬2','공', GETDATE())
insert into card_AIList values ('크게 노린다', '공','스킬1','스킬2','방', GETDATE())
insert into card_AIList values ('무조건 한방', '공','스킬1','스킬2','방', GETDATE())
insert into card_AIList values ('일단 공격', '공','스킬1','스킬2','방', GETDATE())
insert into card_AIList values ('끊어 치기', '공','스킬1','스킬2','방', GETDATE())
insert into card_AIList values ('끊어 치기 2', '공','스킬1','방','스킬2', GETDATE())
select * from card_AIList

drop table card_shuffle_active
create table card_shuffle_active
(	
	subseq int identity(1,1) not null primary key,
	seq int not null,
	s_type varchar(50) not null,
	shuffle varchar(50) not null
)

select * from card_shuffle_active

insert into card_shuffle_active values (3, 'LEFT', '공')
insert into card_shuffle_active values (3, 'LEFT', '마')
insert into card_shuffle_active values (3, 'LEFT', '방')
insert into card_shuffle_active values (3, 'LEFT', '공')
insert into card_shuffle_active values (3, 'LEFT', '공')

insert into card_shuffle_active values (3, 'RIGHT', '공')
insert into card_shuffle_active values (3, 'RIGHT', '마')
insert into card_shuffle_active values (3, 'RIGHT', '방')

insert into card_shuffle_active
select seq, 'RIGHT', '방' from card_user where u_id = 'usaki'

select * from card_shuffle_active order by s_type

select	
	shuffle, COUNT(shuffle) as cnt
from card_shuffle_active where seq = 3 and s_type = 'LEFT'
group by shuffle

select	
	shuffle, COUNT(shuffle) as cnt
from card_shuffle_active where seq = 3 and s_type = 'RIGHT'
group by shuffle

delete from card_shuffle_active where subseq in (
	select subseq from (
		select top 2 subseq from card_shuffle_active where seq in (select seq from card_user where u_id = 'usaki') 
		and s_type = 'LEFT' and shuffle = '마'
	) a
)

select * From card_user
select * from card_battle_main
select * from card_shuffle_active

create table card_memo
(
	seq int identity(1,1) not null primary key,
	u_id varchar(255) null,
	memo varchar(3000) null,
	cre_date datetime default getdate()
)

select * from card_memo

create table card_venture_main
(
	seq int identity(1,1) not null primary key,
	date_ym varchar(8) not null,
	user_seq int not null,
	point int default 0,
	atk_success int default 0,
	atk_fail int default 0,
	def_success int default 0,
	def_fail int default 0		
)

select * from card_venture_main where user_seq in (select seq from card_user where u_id = 'usaki')
insert into card_venture_main
select 
	'299912', seq, 1000, 0, 0, 0 ,0 
from card_user where u_id = 'usaki1'


create table card_venture_sub
(
	seq int identity(1,1) not null primary key,
	subseq int not null,
	battle_seq int not null	
)

delete from card_venture_sub where subseq = 1
insert into card_venture_sub values (1, 48)
insert into card_venture_sub values (1, 196)
insert into card_venture_sub values (1, 197)

select top 7 * from card_venture_main
where user_seq not in (
	select seq from card_user where u_id = 'usaki'
)
order by newid()

select top 7 * from card_battle_main
order by newid()

select * From card_venture_sub a inner join card_battle_main b on a.battle_seq = b.subseq
where a.subseq = 3
order by a.seq

select 
    * 
from card_venture_main a inner join card_venture_sub b 
on a.seq = b.subseq
where user_seq in (
    select seq from card_user where u_id = 'usaki'
)

update card_venture_main
set point = point + 16
where user_seq = 3

select 
    * 
from card_venture_main a inner join card_venture_sub b 
on a.seq = b.subseq
where user_seq in (
    select seq from card_user where u_id = 'usaki'
)
order by b.seq

create table card_simul_info
(
	seq int identity(1,1) not null primary key,
	u_id varchar(255) not null,
	card_name varchar(255) not null,
	card_level varchar(5),
	epic_yn char(1) default 'N',
	stat_health int default 0,
	stat_strong1 int default 0,
	stat_defense int default 0,
	stat_strong2 int default 0,
	
	item1_upgrade_yn char(1) default 'N',
	item1_type varchar(25),
	item1_type_cnt int default 0,
	item1_option1_type varchar(25),
	item1_option1_cnt int default 0,
	item1_option2_type varchar(25),
	item1_option2_cnt int default 0,
	
	item2_upgrade_yn char(1) default 'N',
	item2_type varchar(25),
	item2_type_cnt int default 0,
	item2_option1_type varchar(25),
	item2_option1_cnt int default 0,
	item2_option2_type varchar(25),
	item2_option2_cnt int default 0,
	
	item3_upgrade_yn char(1) default 'N',
	item3_type varchar(25),
	item3_type_cnt int default 0,
	item3_option1_type varchar(25),
	item3_option1_cnt int default 0,
	item3_option2_type varchar(25),
	item3_option2_cnt int default 0,
	
	cre_date datetime default getdate()
)

select * from card_simul_info
where u_id = 'usaki'
order by seq desc

select 
	a.seq,
	a.u_id,
	b.card_name, 
	b.battle_name,
	b.subseq
from card_user a inner join
(
	select 
		subseq, seq, card_name, battle_name
	from card_battle_main
	where ai_name is not null
	and ai_name <> ''
) b on a.seq = b.seq

-- ID별
select 
	a.seq,
	a.u_id as value
from card_user a inner join
(
	select 
		seq, card_name, battle_name
	from card_battle_main
	where ai_name is not null
	and ai_name <> ''
) b on a.seq = b.seq
group by a.seq, a.u_id
order by a.u_id

select * from card_battle_main
where ai_name is not null
and ai_name <> ''
and seq = 3

select * from card_battle_main a inner join 
(
    select seq, u_id from card_user	
) b on a.seq = b.seq and len(a.ai_name) > 0
and a.seq = 3
order by u_id, battle_name, subseq desc

-- card별
select
	b.card_name as seq,
	b.card_name as value
from card_user a inner join
(
	select 
		subseq, seq, card_name, battle_name
	from card_battle_main
	where ai_name is not null
	and ai_name <> ''
) b on a.seq = b.seq
group by b.card_name

select * from card_battle_main
where ai_name is not null
and ai_name <> ''
and card_name = '그라시아'

select * From card_battle_main

create table conn_log
(
	seq int identity(1,1) not null primary key,
	user_ip varchar(25) not null,
	page_name varchar(255) null,
	conn_date date default getdate()
)

insert into conn_log (user_ip, page_name) values ('112.11.121.22','bb.aspx')

select 
	CONVERT(varchar, conn_date, 112) as conn_date,
	user_ip,
	page_name,
	COUNT(*) as cnt,
	(select COUNT(*) as cnt from conn_log) as total_cnt
from conn_log
where substring(CONVERT(varchar, conn_date, 112),1,6) = '201509'
group by conn_date, user_ip, page_name

select * from conn_log order by seq desc 